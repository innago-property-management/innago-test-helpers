# ServiceVerifier.VerifyService method (1 of 6)

Verifies that a service is registered.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService(
    this IServiceCollection serviceCollection, Type serviceType, 
    ServiceLifetime? serviceLifetime = default, bool requireImplementationFactory = false)
```

| parameter | description |
| --- | --- |
| serviceCollection | The IServiceCollection. |
| serviceType | The service type. |
| serviceLifetime | The ServiceLifetime. |
| requireImplementationFactory | If true, the service must have an ImplementationFactory. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService(typeof(IMyType), ServiceLifetime.Singleton, true);
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

---

# ServiceVerifier.VerifyService&lt;TService&gt; method (2 of 6)

Verifies that a service is registered as Transient.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
    this IServiceCollection serviceCollection)
    where TService : class
```

| parameter | description |
| --- | --- |
| TService | The service type. |
| serviceCollection | The IServiceCollection. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService<IMyType>();
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

---

# ServiceVerifier.VerifyService&lt;TService&gt; method (3 of 6)

Verifies that a service is registered.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
    this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime)
    where TService : class
```

| parameter | description |
| --- | --- |
| TService | The service type. |
| serviceCollection | The IServiceCollection. |
| serviceLifetime | The ServiceLifetime. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService<IMyType>(ServiceLifetime.Scoped);
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

---

# ServiceVerifier.VerifyService&lt;TService&gt; method (4 of 6)

Verifies that a service is registered.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService<TService>(
    this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime, 
    bool requireImplementationFactory)
    where TService : class
```

| parameter | description |
| --- | --- |
| TService | The service type. |
| serviceCollection | The IServiceCollection. |
| serviceLifetime | The ServiceLifetime. |
| requireImplementationFactory | If true, the service must have an ImplementationFactory. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService<IMyType>(ServiceLifetime.Singleton, true);
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

---

# ServiceVerifier.VerifyService&lt;TService,TImplementation&gt; method (5 of 6)

Verifies that a service is registered as Transient.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService<TService, TImplementation>(
    this IServiceCollection serviceCollection)
    where TService : class
```

| parameter | description |
| --- | --- |
| TService | The service type. |
| TImplementation | The implementation type. |
| serviceCollection | The IServiceCollection. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService<IMyType, MyType>();
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

---

# ServiceVerifier.VerifyService&lt;TService,TImplementation&gt; method (6 of 6)

Verifies that a service is registered.

```csharp
public static IEnumerable<ServiceDescriptor> VerifyService<TService, TImplementation>(
    this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime)
    where TService : class
```

| parameter | description |
| --- | --- |
| TService | The service type. |
| TImplementation | The implementation type. |
| serviceCollection | The IServiceCollection. |
| serviceLifetime | The ServiceLifetime. |

## Return Value

The ServiceDescriptors for the service.

## Examples

```csharp
serviceCollection.VerifyService<IMyType, MyType>(expectedServiceLifetime);
```

## See Also

* class [ServiceVerifier](../ServiceVerifier.md)
* namespace [Innago.Shared.UnitTesting.TestHelpers](../../Innago.Shared.UnitTesting.TestHelpers.md)

<!-- DO NOT EDIT: generated by xmldocmd for Innago.Shared.UnitTesting.TestHelpers.dll -->
