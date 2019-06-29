using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.LastName;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class LastNameExample
    {
        private readonly StaticVault staticVault;

        public LastNameExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            /*
            * LAST NAME
            */

            // Creating a new LastName
            LastNameResponse created = await Create(staticVault);

            // Retrieving a existent LastName
            LastNameResponse retrieved = await Retrieve(staticVault, created.Id);

            // Deleting a existent LastName
            await Delete(staticVault, retrieved.Id);


            /*
            * LAST NAME WITH GENDER
            */

            // Creating a new LastName
            LastNameResponse createdWithGender = await CreateWithGender(staticVault);

            // Retrieving a existent LastName
            LastNameResponse retrievedWithGender = await Retrieve(staticVault, createdWithGender.Id);

            // Deleting a existent LastName
            await Delete(staticVault, retrievedWithGender.Id);

        }

        private async Task<LastNameResponse> Create(StaticVault vault)
        {
            String name = "example";

            LastNameResponse created = await vault.LastName.Create(name);

            Console.WriteLine("//// LastNameExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<LastNameResponse> CreateWithGender(StaticVault vault)
        {
            String name = "example";
            String gender = "male";

            LastNameResponse created = await vault.LastName.Create(name, gender);

            Console.WriteLine("//// LastNameExample.CreateWithGender:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<LastNameResponse> Retrieve(StaticVault vault, String id)
        {
            LastNameResponse retrieved = await vault.LastName.Retrieve(id);

            Console.WriteLine("//// LastNameExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String lastName)
        {
            var retrieved = await vault.LastName.RetrieveFromRealData(lastName);

            Console.WriteLine("//// LastNameExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.LastName.Delete(id);

            Console.WriteLine("//// LastNameExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
