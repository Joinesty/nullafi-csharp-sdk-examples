using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Generic;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class GenericExample
    {
        private readonly StaticVault staticVault;

        public GenericExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new Generic
            GenericResponse created = await Create(staticVault);

            // Retrieving a existent Generic
            GenericResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Data);

            // Deleting a existent Generic
            await Delete(staticVault, retrieved.Id);
        }

        private async Task<GenericResponse> Create(StaticVault vault)
        {
            String name = "example";

            GenericResponse created = await vault.Generic.Create(name, @"\d{4}");

            Console.WriteLine("//// GenericExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<GenericResponse> Retrieve(StaticVault vault, String id)
        {
            GenericResponse retrieved = await vault.Generic.Retrieve(id);

            Console.WriteLine("//// GenericExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String data)
        {
            var retrieved = await vault.Generic.RetrieveFromRealData(data);

            Console.WriteLine("//// GenericExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Generic.Delete(id);

            Console.WriteLine("//// GenericExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
