using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.PlaceOfBirth;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class PlaceOfBirthExample
    {
        private readonly StaticVault staticVault;

        public PlaceOfBirthExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            /*
            * PLACE OF BIRTH
            */

            // Creating a new Place of Birth
            PlaceOfBirthResponse created = await Create(staticVault);

            // Retrieving a existent Place of Birth
            PlaceOfBirthResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.PlaceOfBirth);

            // Deleting a existent Place of Birth
            await Delete(staticVault, retrieved.Id);

            /*
            * PLACE OF BIRTH WITH STATE
            */

            // Creating a new Place of Birth with State
            PlaceOfBirthResponse createdWithState = await CreateWithState(staticVault);

            // Retrieving a existent Place of Birth
            PlaceOfBirthResponse retrievedWithState = await Retrieve(staticVault, createdWithState.Id);

            await RetrieveFromRealData(staticVault, createdWithState.PlaceOfBirth);

            // Deleting a existent Place of Birth
            await Delete(staticVault, retrievedWithState.Id);


        }

        private async Task<PlaceOfBirthResponse> Create(StaticVault vault)
        {
            String name = "Example With Space";

            PlaceOfBirthResponse created = await vault.PlaceOfBirth.Create(name);

            Console.WriteLine("//// PlaceOfBirthExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<PlaceOfBirthResponse> CreateWithState(StaticVault vault)
        {
            String name = "PlaceOfBirth With State Example";
            String state = "IL";

            PlaceOfBirthResponse created = await vault.PlaceOfBirth.Create(name, state, null);

            Console.WriteLine("//// PlaceOfBirthExample.CreateWithState:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<PlaceOfBirthResponse> Retrieve(StaticVault vault, String id)
        {
            PlaceOfBirthResponse retrieved = await vault.PlaceOfBirth.Retrieve(id);

            Console.WriteLine("//// PlaceOfBirthExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String placeOfBirth)
        {
            var retrieved = await vault.PlaceOfBirth.RetrieveFromRealData(placeOfBirth);

            Console.WriteLine("//// PlaceOfBirthExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.PlaceOfBirth.Delete(id);

            Console.WriteLine("//// PlaceOfBirthExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
