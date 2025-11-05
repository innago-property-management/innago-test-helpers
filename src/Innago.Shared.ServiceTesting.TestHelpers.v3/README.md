# Innago.Shared.ServiceTesting.TestHelpers

This library is intended for integration/system tests (i.e. tests between multiple layers).

It has the benefit that it can be run in CI without the need for DinD (Docker-in-Docker).

To accomplish this, it uses an in-memory EF Core database. Since an in-memory database is not backed by a real database, if your code relies on database-native features, this library in NOT appropriate.

It is *not* intended as a replacement for unit testing, which is more robust; rather, it is intended for scenario verification. 

Examples:

 - when I search for a non-existent entity, I should get a 404.
 - When I request an item using a negative id, I should get a 400.
 - When I request an entity that exists, I should get a response with values that match the database values.
 - When I request an item be saved, it should save correctly in the database.

## Service Test Fixture ##

Inherit from `ServiceTestFixtureBase`.

```c#
[UsedImplicitly]
public sealed class ServiceTestFixture<TProgram, TDbContextFactory, TDbContext> : ServiceTestFixtureBase<TProgram, TDbContextFactory, TDbContext>
    where TProgram : class
    where TDbContextFactory : TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : DbContext
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IAuthorQueryService, AuthorQueryService>();
        services.AddTransient<IAuthorMutationService, AuthorMutationService>();
        services.AddTransient<IBookQueryService, BookQueryService>();
    }
}
```

## Test Database Context Factory ##

Inherit from `TestDatabaseContextFactoryBase` and implement `MakeContext`.

```c#
public class TestDatabaseContextFactory : TestDatabaseContextFactoryBase<DemoDbContext>
{
    protected override DemoDbContext MakeContext(DbContextOptions<DemoDbContext> options)
    {
        return new DemoDbContext(options);
    }
}
```

## Collection Definition ##

Author a class similar to this -- XUnit uses it to guarantee that the state in the fixture is shared between all test classes in the collection.

```c#
[CollectionDefinition($"{nameof(Service)}Tests")]
public sealed class ServiceTestDefinition :
    ICollectionFixture<ServiceTestFixture<Program, TestDatabaseContextFactory, DemoDbContext>>
{
}
```

## Service Test Base ##

This is the base class for all of your service tests.

```c#
[Collection($"{nameof(Service)}Tests")]
public abstract class
    ServiceTestBase<TProgram, TDbContextFactory, TDbContext> : ServiceTestBaseBase<TProgram, TDbContextFactory, TDbContext>
    where TProgram : class
    where TDbContextFactory : TestDatabaseContextFactoryBase<TDbContext>, new()
    where TDbContext : DbContext
{
    protected ServiceTestBase(
        ServiceTestFixture<TProgram, TDbContextFactory, TDbContext> serviceTestFixture) : base(serviceTestFixture)
    {
        this.ServiceTestFixture.DatabaseContextFactory.CreateDbContext().Database.EnsureDeleted();
    }
}
```

## Service Tests ##
Inherit from `ServiceTestBase` which you created above, e.g.

```c#
public class AuthorQueryServiceTests : ServiceTestBase<Program, TestDatabaseContextFactory, DemoDbContext>
{
    // ...
}
```

### Write some tests ###

#### XUnit example ####

```c#
    [Fact]
    public async Task GetAuthorAsync_200()
    {
        Author author = await this.MakeAndSaveAnAuthorInDatabase().ConfigureAwait(false);

        int id = author.Id;
        CancellationToken cancellationToken = default;

        Contracts.Author? actual = await this.Service.GetAuthorAsync(id, cancellationToken).ConfigureAwait(false);

        actual.Id.Should().Be(id);
        actual.FirstName.Should().Be(author.FirstName);
        actual.LastName.Should().Be(author.LastName);
    }
```

#### SpecFlow Example ####

##### Feature #####

```gherkindotnet
Feature: GetAuthorFeature
	Get an author

Scenario: Get a non-existent author
	Given the author 1 is not in the database
	When a request for author 1 is made
	Then the result should be NotFound
```

##### Steps #####

```c#
    private ServiceException? exception;
    private Author? contractAuthor;

    [Given(@"the author (.*) is not in the database")]
    public async Task GivenTheAuthorIsNotInTheDatabase(int id)
    {
        DemoDbContext dbContext = this.ServiceTestFixture.DatabaseContextFactory.CreateDbContext();

        Models.Author? author = await dbContext.Authors.FindAsync(id);

        if (author is null)
        {
            return;
        }

        dbContext.Authors.Remove(author);
        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }
    
    [When("a request for author (.*) is made")]
    public async Task WhenARequestForAuthorIsMade(int id)
    {
        var service = this.ServiceTestFixture.GetService<IAuthorQueryService>();

        try
        {
            this.contractAuthor = await service.GetAuthorAsync(id).ConfigureAwait(false);
        }
        catch (ServiceException e)
        {
            this.exception = e;
        }
    }

    [Then(@"the result should be NotFound")]
    public void ThenTheResultShouldBeNotFound()
    {
        this.exception!.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
```



## Verifying Implicit Publish in Service Tests ##

In your test fixture's `ConfigureServices` method, it is necessary to REPLACE the messaging technology used in your web API.

The following example is for RabbitMQ (NATS is similar):

```c#
protected override void ConfigureServices(IServiceCollection services)
{
    // ...

    services.Replace(ServiceDescriptor.Singleton(ConnectionFactory));
     // ...
}

private static IConnectionFactory ConnectionFactory
{
    get
    {
        var mock = new Mock<IConnectionFactory>(MockBehavior.Strict);

        mock.Setup(factory => factory.CreateConnection())
            .Returns(() => Connection);

        mock.SetupProperty(factory => factory.Uri);

        return mock.Object;
    }
}

private static IConnection Connection
{
    get
    {
        var mock = new Mock<IConnection>(MockBehavior.Strict);

        mock.Setup(connection => connection.CreateModel())
            .Returns(() => Channel);

        return mock.Object;
    }
}

private static IModel Channel
{
    get
    {
        var mock = new Mock<IModel>(MockBehavior.Strict);

        mock.Setup(model =>
            model.ExchangeDeclare(
                It.IsAny<string>(), // exchange
                It.IsAny<string>(), // type
                It.IsAny<bool>(), //durable
                It.IsAny<bool>(), //autoDelete
                It.IsAny<IDictionary<string, object>>() // arguments
            ));

        return mock.Object;
    }
}
```

A note on *`MockBehavior.Strict`*: it can be useful when you are trying to figure out which methods you need to mock since setting the mode to strict will cause an exception that indicates the method that has not been set up; otherwise, using or not using this behavior is a matter of taste -- some test authors like to be very specific; others do not like the maintenance burden it places on their tests.

### To replace the `IPublisher` ###

```c#
protected override void ConfigureServices(IServiceCollection services)
{
  // ...

  services.Replace(ServiceDescriptor.Singleton(ConnectionFactory));
  
  // ...

  services.Replace(ServiceDescriptor.Transient(_ => this.Publisher));
}

private IPublisher? publisher;

private IPublisher Publisher
{
  get
  {
      if (this.publisher is not null)
      {
          return this.publisher;
      }

      var mock = new Mock<IPublisher>();

      this.publisher = mock.Object;

      return this.publisher;
  }
}

```

### To verify a publish ###

In the test class...

```c#
private void VerifyPublish<TId>(TId id, EntityAction entityAction, Times? times = null)
{
    Mock<IPublisher> mock = Mock.Get(this.ServiceTestFixture.GetService<IPublisher>());

    Func<EntityEvent<IEntityInfo<string>, object, string>, bool> verifyPublish = Verify;

    mock.Verify(publisher =>
        publisher.Publish(
            It.Is<EntityEvent<IEntityInfo<string>, object, string>>(entityEvent => verifyPublish(entityEvent))),
        times ?? Times.AtLeastOnce());

    bool Verify(EntityEvent<IEntityInfo<string>, object, string> ev)
    {
        return ev.EntityName == typeof(Author).FullName &&
               ev.EntityId == id!.ToString() &&
               ev.EntityAction == entityAction;
    }
}
```

In your test...

```c#
[Fact]
public async Task DeleteAsync_Record()
{
  Author author = await this.MakeAndSaveAnAuthorInDatabase().ConfigureAwait(false);
  int id = author.Id;
  CancellationToken cancellationToken = default;

  await this.Service.DeleteAsync(id, cancellationToken).ConfigureAwait(false);
  
	// ...

  this.VerifyPublish(id, EntityAction.Delete);
}
```

