using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.FirstName;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class FirstNameExample
    {
        private readonly StaticVault staticVault;

        public FirstNameExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {
            /*
            * FIRST NAME
            */

            // Creating a new FirstName
            FirstNameResponse created = await Create(staticVault);

            // Retrieving a existent FirstName
            FirstNameResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.FirstName);

            // Deleting a existent FirstName
            await Delete(staticVault, retrieved.Id);


            /*
            * FIRST NAME WITH GENDER
            */

            // Creating a new FirstName
            FirstNameResponse createdWithGender = await CreateWithGender(staticVault);

            // Retrieving a existent FirstName
            FirstNameResponse retrievedWithGender = await Retrieve(staticVault, createdWithGender.Id);

            await RetrieveFromRealData(staticVault, createdWithGender.FirstName);

            // Deleting a existent FirstName
            await Delete(staticVault, retrievedWithGender.Id);

        }

        private async Task<FirstNameResponse> Create(StaticVault vault)
        {
            String name = "example";

            FirstNameResponse created = await vault.FirstName.Create(name);

            Console.WriteLine("//// FirstNameExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<FirstNameResponse> CreateWithGender(StaticVault vault)
        {
            String name = "example";
            String gender = "male";

            FirstNameResponse created = await vault.FirstName.Create(name, gender);

            Console.WriteLine("//// FirstNameExample.CreateWithGender:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<FirstNameResponse> Retrieve(StaticVault vault, String id)
        {
            FirstNameResponse retrieved = await vault.FirstName.Retrieve(id);

            Console.WriteLine("//// FirstNameExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;
        }

        private async Task RetrieveFromRealData(StaticVault vault, String firstName)
        {
            var retrieved = await vault.FirstName.RetrieveFromRealData(firstName);

            Console.WriteLine("//// FirstNameExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.FirstName.Delete(id);

            Console.WriteLine("//// FirstNameExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
