## Installation

Install this package from [nuget](https://nuget.org/packages/Pidget.Client) via the dotnet cli 

```
dotnet add package Pidget.Client
```

[![NuGet](https://img.shields.io/nuget/v/Pidget.Client.svg)](https://nuget.org/packages/Pidget.Client)
[![NuGet](https://img.shields.io/nuget/dt/Pidget.Client.svg)](https://nuget.org/packages/Pidget.Client)

## Usage

Client initialization:

```csharp
var dsn = Dsn.Create("<your DSN>");
var client = Sentry.CreateClient(dsn);
```

Capturing an exception:

```csharp
    // ...
}
catch (Exception ex)
{
    var response = await client.CaptureAsync(e => e.SetException(ex));
    
    // ...
}
```

Capturing a message:

```csharp
var response = await client.CaptureAsync(e => e.SetMessage("Foo"));
```

Using the sentry event builder API:

```csharp
var response = await client.CaptureAsync(e => e
    .SetException(exception)
    .SetErrorLevel(ErrorLevel.Fatal)
    .SetTransaction("/index")
    .SetMessage("Whoops!")
    .AddTag("ios_version", "8.0")
    .AddExtraData("payload", payload)
    .AddFingerprintData("environment:dev"));
```
