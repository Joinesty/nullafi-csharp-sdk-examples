using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Ssn;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class SsnExample
    {
        private readonly StaticVault staticVault;

        public SsnExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            /*
            * SSN
            */

            // Creating a new Ssn
            SsnResponse created = await Create(staticVault);

            // Retrieving a existent Ssn
            SsnResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Ssn);

            // Deleting a existent Ssn
            await Delete(staticVault, retrieved.Id);

            /*
            * SSN WITH STATE
            */

            // Creating a new Ssn with State
            SsnResponse createdWithState = await CreateWithState(staticVault);

            // Retrieving a existent Ssn
            SsnResponse retrievedWithState = await Retrieve(staticVault, createdWithState.Id);

            await RetrieveFromRealData(staticVault, createdWithState.Ssn);

            // Deleting a existent Ssn
            await Delete(staticVault, retrievedWithState.Id);

        }

        private async Task<SsnResponse> Create(StaticVault vault)
        {
            String name = "example";

            SsnResponse created = await vault.Ssn.Create(name);

            Console.WriteLine("//// SsnExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<SsnResponse> CreateWithState(StaticVault vault)
        {
            String name = "Ssn With State Example";
            String state = "IL";

            SsnResponse created = await vault.Ssn.Create(name, state, null);

            Console.WriteLine("//// SsnExample.CreateWithState:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<SsnResponse> Retrieve(StaticVault vault, String id)
        {
            SsnResponse retrieved = await vault.Ssn.Retrieve(id);

            Console.WriteLine("//// SsnExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String ssn)
        {
            var retrieved = await vault.Ssn.RetrieveFromRealData(ssn);

            Console.WriteLine("//// SsnExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Ssn.Delete(id);

            Console.WriteLine("//// SsnExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
