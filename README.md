
Nullafi C# SDK Examples
===============

A C# Application with examples to use the Nullafi C# SDK.

- [Pre Requisites](#pre-requisites)
- [How to use the SDK at your project](#how-to-use-the-sdk-at-your-project)
- [Getting Started](#getting-started)
- [Copyright and License](#copyright-and-license)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

How to use the SDK at your project
------------
- Import the NullafiSDK Package from [Nuget Repository](https://www.nuget.org/packages/NullafiSDK/). Examples:
```
Package Manager
PM> Install-Package NullafiSDK
```
```
.NET CLI
> dotnet add package NullafiSDK
```
```
Paket CLI
> paket add NullafiSDK
```

[The most recent version of the Nullafi Java SDK can be found on Maven Repository.](https://www.nuget.org/packages/NullafiSDK/)

Getting Started
---------------

- To get started with the Examples, get a API Key from the Configuration page
of your app in the [Settings Page - API Key][settings-api-key]. You can use this token to make calls for your own Nullafi account.

- All vaults and tokens examples are in `NullafiSDKExamples/Examples` folder.

- Run `NullafiSDKExamples` console project to view all examples working.

```csharp
using System;

namespace NullafiSDKExamples
{
    class Program
    {
        static readonly string API_KEY = "YOUR_API_KEY";

        public static void Main(String[] args)
        {
            var examples = new Examples.Examples(API_KEY);
            examples.Run().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
```

[settings-api-key]: https://dashboard.nullafi.com/admin/settings/api


Copyright and License
---------------------

Copyright 2019 Joinesty, Inc. All rights reserved.
