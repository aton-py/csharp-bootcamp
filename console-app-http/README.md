# Setup

The base premise of this example is going to be a simple console 
application written in C#. It will be a .NET 5 console application and 
to aid with simplicity I will be using the "Top Level Statement" feature
 to remove some of the boiler plate code which can look intimidating to 
less experienced developers.

To start off we create a new console application. All the examples 
will be done through the dotnet cli. This command will create a new 
console application and put it in the `TestConsoleApplication` folder.

```
dotnet new console -o TestConsoleApplication

```

We now need to add some nuget packages to aid us with the management and instantiation of our HttpClient instance.

Now once you've navigated inside the "TestConsoleApplication" folder 
we need to execute the following commands to add the nuget packages.

```
dotnet add package Microsoft.Extensions.DependencyInjection --version 5.0.1

```

This will add in the dependency injection library functionality which we will be using.

```
dotnet add package Microsoft.Extensions.Http --version 5.0.0

```

This package will add in the ability to use HttpClient and the infrastructure around it to work with dependency injection.

Once you have run both these command and open the csproj file for the
 console application you should now see those packages referenced.

```
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="5.0.1" />
    <PackageReference Include="Microsoft.Extensions.Http" Version="5.0.0" />
  </ItemGroup>

```

If you don't see the package references as per the item group example
 above then make sure you have run the commands against the correct 
project file.

# Making the Request

To make a http request in C# for most use cases the type you want to interact with is `HttpClient`. This allows for making requests for the different http method verbs with sending and receiving data payloads.

As I said before you can instantiate an new `HttpClient` 
instance manually but depending on the use case and how long the process
 is running for this can lead to a problem called "port exhaustion". Due
 to the way network connections are made if they aren't closed properly 
it can leave a connection open. If too many of these are made without 
them being tidied up then the system can run out of connections. To 
solve this you can use the Http extensions library from Microsoft and 
this manages lifetimes, reuse of HttpClient instances etc. to try and 
avoid this issue.

To allow us access to `HttpClient` we are going to create a `ServiceCollection`
 and register the required services with the collection. We will then 
create a service provider which is our entry point into requesting 
types.

That sentence can sound a bit scary so let's break that down.

A service collection is just a collection of items much like you might defined a `List<T>` in your application to store you own items. The `ServiceCollection` is a targetted collection which holds a list of `ServiceDescriptor`. This type is used to setup the types we might want during our application.

The "required services" are the framework types to make things work when we make the request for a `HttpClient` instance. The types registered will allow the service provider to give us the type we want ready to use when asked for.

A service provider is the core mechanism for dependency injection. In
 a console application it is the type we ask to provide us with the 
types we want for our application to function.

```
var services = new ServiceCollection();
services.AddHttpClient();
var serviceProvider = services.BuildServiceProvider();

```

Once we've registered all the types we need and created our service provider we can now request a HttpClient.

```
var client = serviceProvider.GetService<HttpClient>();

```

Once we have the client we can make the request.

```
var response = await client.GetFromJsonAsync<ChuckNorrisJoke>("https://api.chucknorris.io/jokes/random");

```

In this simple example we are using a free simple json api which 
returns random Chuck Norris related jokes. I don't control the content 
of this api but it allows for simple examples so it can be used as a 
demo to programmatically interact with a json api.

The ChuckNorrisJoke type is a record type defined which the response 
data will be deserialize into to aid with working with the data.

```
public record ChuckNorrisJoke(string Id, string Value, string Url);

```

And that's it. As simple as that.

# Full Example

```
using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient();
var serviceProvider = services.BuildServiceProvider();

var client = serviceProvider.GetService<HttpClient>();
var response = await client.GetFromJsonAsync<ChuckNorrisJoke>("https://api.chucknorris.io/jokes/random");

Console.WriteLine($"Id: {response.Id}");
Console.WriteLine($"Joke: {response.Value}");

public record ChuckNorrisJoke(string Id, string Value, string Url);

```

Due to the types we are using there are a few using statements at the
 top so the code knows where to find the specific types but as can see 
in less than 20 lines of code we have setup dependency injection, 
requested a `HttpClient`, made a request to a json api and processed the strongly typed response.

# Adding a Strongly Typed Client

Making requests like the above are fine, however there are times when
 you want more control over the structure of the request or you want to 
add readability, maintainability and testability to your code. To do 
this you don't want to "leak" the different abstraction layers in your 
code.

What does this mean? Well in the above we are making requests to an 
explicit url and processing the data. The consumer of this data doesn't 
want to or need to know that it came from a http end point or a database
 etc. To allow for the consuming code to say "please can I have a random
 joke about Chuck Norris?" we can wrap up the processing into a custom 
type.

## ChuckNorrisClient

To do this we create our own type. This allows us to specify the 
method name to be clear to the consumer and handles all the 
communication under the hood so the caller doesn't need to know.

```
public class ChuckNorrisClient
{
    private readonly HttpClient _httpClient;

    public ChuckNorrisClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ChuckNorrisJoke> GetRandomJokeAsync() => await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");
}

```

This type is dependent on `HttpClient`. An instance of `HttpClient`
 is required for the constructor to be used. This is "injected" through 
the processing of the Service Provider. This is what is referred as 
Constructor Injection. As we're constructing the required services and 
requesting services through the service provider all the dependency tree
 generation is being done for us. This concept is really powerful 
especially as your services grow and more complexity is introduced into 
your codebase.

## Registering the ChuckNorrisClient

We now need to register the client with the service collection. As it requires a `HttpClient` in it's constructor we use a different version of the `AddHttpClient` extension method we used before when adding the `HttpClient` related types to the service collection.

```
var services = new ServiceCollection();
services.AddHttpClient<ChuckNorrisClient>(c => c.BaseAddress = new Uri("https://api.chucknorris.io/"));
var serviceProvider = services.BuildServiceProvider();

```

In the above we are saying that the `ChuckNorrisClient` is to be registered with the service collection but it's special and it is dependent on `HttpClient`. When a `ChuckNorrisClient` instance is requested from the service provider a `HttpClient` instance needs to be injected into it however make sure that the `BaseAddress` is preconfigured and set to the chucknorris api root uri.

As we set the base address when our client type is registered when we make the `GetFromJsonAsync` request inside the `GetRandomJokeAsync` method we only require the path of the request to be executed not the full url.

## Executing the Request

Now the strongly typed client has been registered and configured through the `AddHttpClient` call we can now request a constructed instance from the service provider and call the `GetRandomJokeAsync` method on the instance to request a joke from the API.

```
var client = serviceProvider.GetService<ChuckNorrisClient>();
var response = await client.GetRandomJokeAsync();

```

# Full Strongly Typed Example

```
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient<ChuckNorrisClient>(c => c.BaseAddress = new Uri("https://api.chucknorris.io/"));
var serviceProvider = services.BuildServiceProvider();

var client = serviceProvider.GetService<ChuckNorrisClient>();
var response = await client.GetRandomJokeAsync();

System.Console.WriteLine($"Id: {response.Id}");
System.Console.WriteLine($"Joke: {response.Value}");

public record ChuckNorrisJoke(string Id, string Value, string Url);

public class ChuckNorrisClient
{
    private readonly HttpClient _httpClient;

    public ChuckNorrisClient(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ChuckNorrisJoke> GetRandomJokeAsync() => await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");
}

```

As you can see from the above the construction of the call to the api is very similar to using a `HttpClient` directly but allows for abstraction separation.

# Conclusion

We have looked at how to make a request to a JSON Api 
end point using C# and .NET. I hope less experienced developers find this useful. With the 
interconnected world we live in the more systems which are built the 
more integration requests, for example via Http, will need to be made. 
The complexities of handling errors, retry policies etc. has been out of
 scope but if you are looking for more information on that I would look 
for the "Polly" library.