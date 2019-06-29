using Nullafi.Domains.StaticVault;
using Nullafi.Domains.StaticVault.Managers.DateOfBirth;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static.Managers
{
    class DateOfBirthExample
    {
        private readonly StaticVault staticVault;

        public DateOfBirthExample(StaticVault staticVault)
        {
            this.staticVault = staticVault;
        }

        public async Task Run()
        {

            /*
             * DATE OF BIRTH
             */

            // Creating a new DateOfBirth
            DateOfBirthResponse created = await Create(staticVault);

            // Retrieving a existent DateOfBirth
            DateOfBirthResponse retrieved = await Retrieve(staticVault, created.Id);

            await RetrieveFromRealData(staticVault, created.DateOfBirth);

            // Deleting a existent DateOfBirth
            await Delete(staticVault, retrieved.Id);

            /*
             * DATE OF BIRTH WITH YEAR
             */

            // Creating a new DateOfBirth
            DateOfBirthResponse createdWithYear = await CreateWithYear(staticVault);

            // Retrieving a existent DateOfBirth
            DateOfBirthResponse retrievedWithYear = await Retrieve(staticVault, createdWithYear.Id);

            await RetrieveFromRealData(staticVault, createdWithYear.DateOfBirth);

            // Deleting a existent DateOfBirth
            await Delete(staticVault, retrievedWithYear.Id);

            /*
             * DATE OF BIRTH WITH MONTH
             */

            // Creating a new DateOfBirth
            DateOfBirthResponse createdWithMonth = await CreateWithMonth(staticVault);

            // Retrieving a existent DateOfBirth
            DateOfBirthResponse retrievedWithMonth = await Retrieve(staticVault, createdWithMonth.Id);

            await RetrieveFromRealData(staticVault, created.DateOfBirth);

            // Deleting a existent DateOfBirth
            await Delete(staticVault, retrievedWithMonth.Id);

            /*
             * DATE OF BIRTH WITH YEAR AND MONTH
             */

            // Creating a new DateOfBirth
            DateOfBirthResponse createdWithYearMonth = await CreateWithYearMonth(staticVault);

            // Retrieving a existent DateOfBirth
            DateOfBirthResponse retrievedWithYearMonth = await Retrieve(staticVault, createdWithYearMonth.Id);

            await RetrieveFromRealData(staticVault, createdWithYearMonth.DateOfBirth);

            // Deleting a existent DateOfBirth
            await Delete(staticVault, retrievedWithYearMonth.Id);


        }

        private async Task<DateOfBirthResponse> Create(StaticVault vault)
        {
            String name = "example";

            DateOfBirthResponse created = await vault.DateOfBirth.Create(name);

            Console.WriteLine("//// DateOfBirthExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DateOfBirthResponse> CreateWithMonth(StaticVault vault)
        {
            String name = "example";
            int month = 1;

            DateOfBirthResponse created = await vault.DateOfBirth.Create(name, null, month);

            Console.WriteLine("//// DateOfBirthExample.createWithMonth:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DateOfBirthResponse> CreateWithYear(StaticVault vault)
        {
            String name = "example";
            int year = 1991;

            DateOfBirthResponse created = await vault.DateOfBirth.Create(name, year);

            Console.WriteLine("//// DateOfBirthExample.createWithYear:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DateOfBirthResponse> CreateWithYearMonth(StaticVault vault)
        {
            String name = "example";
            int month = 1;
            int year = 1991;

            DateOfBirthResponse created = await vault.DateOfBirth.Create(name, year, month);

            Console.WriteLine("//// DateOfBirthExample.createWithYearMonth:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<DateOfBirthResponse> Retrieve(StaticVault vault, String id)
        {
            DateOfBirthResponse retrieved = await vault.DateOfBirth.Retrieve(id);

            Console.WriteLine("//// DateOfBirthExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;

        }

        private async Task RetrieveFromRealData(StaticVault vault, String dateOfBirth)
        {
            var retrieved = await vault.DateOfBirth.RetrieveFromRealData(dateOfBirth);

            Console.WriteLine("//// DateOfBirthExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(StaticVault vault, String id)
        {
            await vault.DateOfBirth.Delete(id);

            Console.WriteLine("//// DateOfBirthExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
