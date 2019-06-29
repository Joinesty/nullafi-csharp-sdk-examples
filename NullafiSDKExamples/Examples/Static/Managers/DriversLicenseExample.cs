using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.DriversLicense;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class DriversLicenseExample
    {
        private readonly StaticVault staticVault;

        public DriversLicenseExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            /*
            * DRIVER LICENSE
            */

            // Creating a new Driver License
            DriversLicenseResponse created = await Create(staticVault);
            
            // Retrieving a existent Driver License
            DriversLicenseResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.DriversLicense);
            
            // Deleting a existent Driver License
            await Delete(staticVault, retrieved.Id);

            /*
            * DRIVER LICENSE WITH STATE
            */

            // Creating a new Driver License with State
            DriversLicenseResponse createdWithState = await CreateWithState(staticVault);

            // Retrieving a existent Driver License
            DriversLicenseResponse retrievedWithState = await Retrieve(staticVault, createdWithState.Id);

            await RetrieveFromRealData(staticVault, createdWithState.DriversLicense);

            // Deleting a existent Driver License
            await Delete(staticVault, retrievedWithState.Id);

        }

        private async Task<DriversLicenseResponse> Create(StaticVault vault)
        {
            String name = "example";

            DriversLicenseResponse created = await vault.DriversLicense.Create(name);

            Console.WriteLine("//// DriversLicenseExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DriversLicenseResponse> CreateWithState(StaticVault vault)
        {
            String name = "DriversLicense With State Example";
            String state = "IL";
            
            DriversLicenseResponse created = await vault.DriversLicense.Create(name, state);

            Console.WriteLine("//// DriversLicenseExample.CreateWithState:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DriversLicenseResponse> Retrieve(StaticVault vault, String id)
        {
            DriversLicenseResponse retrieved = await vault.DriversLicense.Retrieve(id);

            Console.WriteLine("//// DriversLicenseExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String driversLicense)
        {
            var retrieved = await vault.DriversLicense.RetrieveFromRealData(driversLicense);

            Console.WriteLine("//// DriversLicenseExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.DriversLicense.Delete(id);

            Console.WriteLine("//// DriversLicenseExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
