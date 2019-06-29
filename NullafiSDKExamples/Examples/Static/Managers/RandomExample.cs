using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Random;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class RandomExample
    {
        private readonly StaticVault staticVault;

        public RandomExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new Random
            RandomResponse created = await Create(staticVault);

            // Retrieving a existent Random
            RandomResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Data);

            // Deleting a existent Random
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<RandomResponse> Create(StaticVault vault)
        {
            String name = "example";

            RandomResponse created = await vault.Random.Create(name);

            Console.WriteLine("//// RandomExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<RandomResponse> Retrieve(StaticVault vault, String id)
        {
            RandomResponse retrieved = await vault.Random.Retrieve(id);

            Console.WriteLine("//// RandomExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String data)
        {
            var retrieved = await vault.Random.RetrieveFromRealData(data);

            Console.WriteLine("//// RandomExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Random.Delete(id);

            Console.WriteLine("//// RandomExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
