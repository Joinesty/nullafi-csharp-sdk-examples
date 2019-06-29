using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.TaxPayer;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class TaxPayerExample
    {
        private readonly StaticVault staticVault;

        public TaxPayerExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new TaxPayer
            TaxPayerResponse created = await Create(staticVault);

            // Retrieving a existent TaxPayer
            TaxPayerResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.TaxPayer);

            // Deleting a existent TaxPayer
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<TaxPayerResponse> Create(StaticVault vault)
        {
            String name = "example";


            TaxPayerResponse created = await vault.TaxPayer.Create(name);

            Console.WriteLine("//// TaxPayerExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<TaxPayerResponse> Retrieve(StaticVault vault, String id)
        {
            TaxPayerResponse retrieved = await vault.TaxPayer.Retrieve(id);

            Console.WriteLine("//// TaxPayerExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String taxpayer)
        {
            var retrieved = await vault.TaxPayer.RetrieveFromRealData(taxpayer);

            Console.WriteLine("//// TaxPayerExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.TaxPayer.Delete(id);

            Console.WriteLine("//// TaxPayerExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
