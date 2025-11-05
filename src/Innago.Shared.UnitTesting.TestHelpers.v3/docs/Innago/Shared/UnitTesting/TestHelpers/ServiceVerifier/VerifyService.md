### [Innago\.Shared\.UnitTesting\.TestHelpers](../index.md 'Innago\.Shared\.UnitTesting\.TestHelpers').[ServiceVerifier](index.md 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier')

## ServiceVerifier\.VerifyService Method

| Overloads | |
| :--- | :--- |
| [VerifyService\(this IServiceCollection, Type, Nullable&lt;ServiceLifetime&gt;, bool\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type, System\.Nullable\<Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\>, bool\)') | Verifies that a service is registered\. |
| [VerifyService&lt;TService,TImplementation&gt;\(this IServiceCollection\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\<TService,TImplementation\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Verifies that a service is registered as [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime.transient 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient')\. |
| [VerifyService&lt;TService,TImplementation&gt;\(this IServiceCollection, ServiceLifetime\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\<TService,TImplementation\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\)') | Verifies that a service is registered\. |
| [VerifyService&lt;TService&gt;\(this IServiceCollection\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Verifies that a service is registered as [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime.transient 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient')\. |
| [VerifyService&lt;TService&gt;\(this IServiceCollection, ServiceLifetime\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\)') | Verifies that a service is registered\. |
| [VerifyService&lt;TService&gt;\(this IServiceCollection, ServiceLifetime, bool\)](VerifyService.md#Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool) 'Innago\.Shared\.UnitTesting\.TestHelpers\.ServiceVerifier\.VerifyService\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime, bool\)') | Verifies that a service is registered\. |

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool)'></a>

## ServiceVerifier\.VerifyService\(this IServiceCollection, Type, Nullable\<ServiceLifetime\>, bool\) Method

Verifies that a service is registered\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection, System.Type serviceType, System.Nullable<Microsoft.Extensions.DependencyInjection.ServiceLifetime> serviceLifetime=null, bool requireImplementationFactory=false);
```
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The service type\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool).serviceLifetime'></a>

`serviceLifetime` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type,System.Nullable_Microsoft.Extensions.DependencyInjection.ServiceLifetime_,bool).requireImplementationFactory'></a>

`requireImplementationFactory` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the service must have an [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor\.ImplementationFactory](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor.implementationfactory 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor\.ImplementationFactory')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService(typeof(IMyType), ServiceLifetime.Singleton, true);
```

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection)'></a>

## ServiceVerifier\.VerifyService\<TService,TImplementation\>\(this IServiceCollection\) Method

Verifies that a service is registered as [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime.transient 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient')\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService<TService,TImplementation>(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    where TService : class;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService'></a>

`TService`

The service type\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TImplementation'></a>

`TImplementation`

The implementation type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService<IMyType, MyType>();
```

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime)'></a>

## ServiceVerifier\.VerifyService\<TService,TImplementation\>\(this IServiceCollection, ServiceLifetime\) Method

Verifies that a service is registered\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService<TService,TImplementation>(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection, Microsoft.Extensions.DependencyInjection.ServiceLifetime serviceLifetime)
    where TService : class;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).TService'></a>

`TService`

The service type\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).TImplementation'></a>

`TImplementation`

The implementation type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).serviceLifetime'></a>

`serviceLifetime` [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')

The [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService<IMyType, MyType>(expectedServiceLifetime);
```

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection)'></a>

## ServiceVerifier\.VerifyService\<TService\>\(this IServiceCollection\) Method

Verifies that a service is registered as [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime.transient 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime\.Transient')\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService<TService>(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    where TService : class;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService'></a>

`TService`

The service type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService<IMyType>();
```

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime)'></a>

## ServiceVerifier\.VerifyService\<TService\>\(this IServiceCollection, ServiceLifetime\) Method

Verifies that a service is registered\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService<TService>(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection, Microsoft.Extensions.DependencyInjection.ServiceLifetime serviceLifetime)
    where TService : class;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).TService'></a>

`TService`

The service type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime).serviceLifetime'></a>

`serviceLifetime` [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')

The [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService<IMyType>(ServiceLifetime.Scoped);
```

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool)'></a>

## ServiceVerifier\.VerifyService\<TService\>\(this IServiceCollection, ServiceLifetime, bool\) Method

Verifies that a service is registered\.

```csharp
public static System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor> VerifyService<TService>(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection, Microsoft.Extensions.DependencyInjection.ServiceLifetime serviceLifetime, bool requireImplementationFactory)
    where TService : class;
```
#### Type parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool).TService'></a>

`TService`

The service type\.
#### Parameters

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool).serviceCollection'></a>

`serviceCollection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool).serviceLifetime'></a>

`serviceLifetime` [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')

The [Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicelifetime 'Microsoft\.Extensions\.DependencyInjection\.ServiceLifetime')\.

<a name='Innago.Shared.UnitTesting.TestHelpers.ServiceVerifier.VerifyService_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.DependencyInjection.ServiceLifetime,bool).requireImplementationFactory'></a>

`requireImplementationFactory` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

If true, the service must have an [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor\.ImplementationFactory](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor.implementationfactory 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor\.ImplementationFactory')\.

#### Returns
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')  
The [Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.servicedescriptor 'Microsoft\.Extensions\.DependencyInjection\.ServiceDescriptor')s for the service\.

### Example

```csharp
serviceCollection.VerifyService<IMyType>(ServiceLifetime.Singleton, true);
```