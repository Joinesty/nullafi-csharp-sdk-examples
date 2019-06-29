using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Address;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class AddressExample
    {
        private readonly StaticVault staticVault;

        public AddressExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {
            /*
            * ADDRESS
            */

            // Creating a new Address
            AddressResponse created = await Create(staticVault);
            
            // Retrieving a existent Address
            AddressResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Address);
            
            // Deleting a existent Address
            await Delete(staticVault, retrieved.Id);

            /*
            * ADDRESS WITH STATE
            */

            // Creating a new Address with State
            AddressResponse createdWithState = await CreateWithState(staticVault);

            // Retrieving a existent Address
            AddressResponse retrievedWithState = await Retrieve(staticVault, createdWithState.Id);
            
            await RetrieveFromRealData(staticVault, createdWithState.Address);

            // Deleting a existent Address
            await Delete(staticVault, retrievedWithState.Id);

        }

        private async Task<AddressResponse> Create(StaticVault vault)
        {
            String name = "Address";
            
            AddressResponse created = await vault.Address.Create(name, null);

            Console.WriteLine("//// AddressExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<AddressResponse> CreateWithState(StaticVault vault)
        {
            String name = "Address With State Example";
            String state = "IL";
            
            AddressResponse created = await vault.Address.Create(name, state);

            Console.WriteLine("//// AddressExample.CreateWithState:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<AddressResponse> Retrieve(StaticVault vault, String id)
        {
            AddressResponse retrieved = await vault.Address.Retrieve(id);

            Console.WriteLine("//// AddressExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String address)
        {
            var retrieved = await vault.Address.RetrieveFromRealData(address);

            Console.WriteLine("//// AddressExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Address.Delete(id);

            Console.WriteLine("//// AddressExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
