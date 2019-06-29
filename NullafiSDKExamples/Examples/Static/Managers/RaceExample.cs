using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.Race;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class RaceExample
    {
        private readonly StaticVault staticVault;

        public RaceExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            // Creating a new Race
            RaceResponse created = await Create(staticVault);

            // Retrieving a existent Race
            RaceResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.Race);

            // Deleting a existent Race
            await Delete(staticVault, retrieved.Id);

        }

        private async Task<RaceResponse> Create(StaticVault vault)
        {
            String name = "example";

            RaceResponse created = await vault.Race.Create(name);

            Console.WriteLine("//// RaceExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<RaceResponse> Retrieve(StaticVault vault, String id)
        {
            RaceResponse retrieved = await vault.Race.Retrieve(id);

            Console.WriteLine("//// RaceExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String race)
        {
            var retrieved = await vault.Race.RetrieveFromRealData(race);

            Console.WriteLine("//// RaceExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            RaceManager raceManager = vault.Race;

            await raceManager.Delete(id);

            Console.WriteLine("//// RaceExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
