
Nullafi C# SDK Examples
===============

A C# Application with examples to use the Nullafi C# SDK.

- [Pre Requisites](#pre-requisites)
- [Installation](#installation)
- [Getting Started](#getting-started)
- [Copyright and License](#copyright-and-license)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

Pre Requisites
------------
- .Net Core >= 2.1

Installation
------------
- Import dll (`local-package/NullafiSDK.dll`) to Application

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
