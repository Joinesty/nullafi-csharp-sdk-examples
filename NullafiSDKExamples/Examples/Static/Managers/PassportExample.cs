using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Passport;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class PassportExample
    {
        private readonly StaticVault staticVault;

        public PassportExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new Passport
            PassportResponse created = await Create(staticVault);

            // Retrieving a existent Passport
            PassportResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Passport);

            // Deleting a existent Passport
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<PassportResponse> Create(StaticVault vault)
        {
            String name = "example";

            PassportResponse created = await vault.Passport.Create(name);

            Console.WriteLine("//// PassportExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<PassportResponse> Retrieve(StaticVault vault, String id)
        {
            PassportResponse retrieved = await vault.Passport.Retrieve(id);

            Console.WriteLine("//// PassportExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String passport)
        {
            var retrieved = await vault.Passport.RetrieveFromRealData(passport);

            Console.WriteLine("//// PassportExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.Passport.Delete(id);

            Console.WriteLine("//// PassportExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
