using Nullafi;
using NullafiSDKExamples.Examples.Communication;
using NullafiSDKExamples.Examples.Static;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples
{
    class Examples
    {
        readonly string apiKey;

        public Examples(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task Run()
        {
            var SDK = new NullafiSDK(apiKey);
            var client = await SDK.CreateClient();

            await new CommunicationVaultExample(client).Run();
            await new StaticVaultExample(client).Run();

            Console.Read();
        }
    }
}
