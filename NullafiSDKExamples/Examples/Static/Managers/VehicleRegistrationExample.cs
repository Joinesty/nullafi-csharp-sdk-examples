using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.VehicleRegistration;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class VehicleRegistrationExample
    {
        private readonly StaticVault staticVault;

        public VehicleRegistrationExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new VehicleRegistration
            VehicleRegistrationResponse created = await Create(staticVault);

            // Retrieving a existent VehicleRegistration
            VehicleRegistrationResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.VehicleRegistration);

            // Deleting a existent VehicleRegistration
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<VehicleRegistrationResponse> Create(StaticVault vault)
        {
            String name = "example";

            VehicleRegistrationResponse created = await vault.VehicleRegistration.Create(name);

            Console.WriteLine("//// VehicleRegistrationExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<VehicleRegistrationResponse> Retrieve(StaticVault vault, String id)
        {
            VehicleRegistrationResponse retrieved = await vault.VehicleRegistration.Retrieve(id);

            Console.WriteLine("//// VehicleRegistrationExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String vehicleRegistration)
        {
            var retrieved = await vault.VehicleRegistration.RetrieveFromRealData(vehicleRegistration);

            Console.WriteLine("//// VehicleRegistrationExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.VehicleRegistration.Delete(id);

            Console.WriteLine("//// VehicleRegistrationExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
