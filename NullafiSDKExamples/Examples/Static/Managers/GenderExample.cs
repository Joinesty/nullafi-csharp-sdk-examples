using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Gender;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class GenderExample
    {
        private readonly StaticVault staticVault;

        public GenderExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new Gender
            GenderResponse created = await Create(staticVault);

            // Retrieving a existent Gender
            GenderResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Gender);

            // Deleting a existent Gender
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<GenderResponse> Create(StaticVault vault)
        {
            String name = "example";

            GenderResponse created = await vault.Gender.Create(name);

            Console.WriteLine("//// GenderExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<GenderResponse> Retrieve(StaticVault vault, String id)
        {
            GenderResponse retrieved = await vault.Gender.Retrieve(id);

            Console.WriteLine("//// GenderExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String gender)
        {
            var retrieved = await vault.Gender.RetrieveFromRealData(gender);

            Console.WriteLine("//// GenderExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Gender.Delete(id);

            Console.WriteLine("//// GenderExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
