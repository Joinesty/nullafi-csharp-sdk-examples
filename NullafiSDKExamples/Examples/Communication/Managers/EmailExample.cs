using Nullafi.Domains.CommunicationVault;
using Nullafi.Domains.CommunicationVault.Managers.Email;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Communication.Managers
{
    class EmailExample
    {
        private readonly CommunicationVault communicationVault;

        public EmailExample(CommunicationVault communicationVault)
        {
            this.communicationVault = communicationVault;
        }

        public async Task Run()
        {
            // Creating a new Email
            EmailResponse created = await Create(communicationVault);

            // Retrieving a existent Email
            EmailResponse retrieved = await Retrieve(communicationVault, created.Id);
            await RetrieveFromRealData(communicationVault, created.Email);

            // Deleting a existent Email
            await Delete(communicationVault, retrieved.Id);
        }

        private async Task<EmailResponse> Create(CommunicationVault vault)
        {
            String name = "emai@example.com";

            EmailResponse created = await vault.Email.Create(name);

            Console.WriteLine("//// EmailExample.create:");
            Console.WriteLine("/// Name: " + name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(created));

            return created;
        }

        private async Task<EmailResponse> Retrieve(CommunicationVault vault, String id)
        {
            EmailResponse retrieved = await vault.Email.Retrieve(id);

            Console.WriteLine("//// EmailExample.retrieve:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));

            return retrieved;
        }

        private async Task RetrieveFromRealData(CommunicationVault vault, String email)
        {
            var retrieved = await vault.Email.RetrieveFromRealData(email);

            Console.WriteLine("//// EmailExample.retrieveFromRealData:");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(retrieved));
        }

        private async Task Delete(CommunicationVault vault, String id)
        {
            await vault.Email.Delete(id);

            Console.WriteLine("//// EmailExample.delete:");
            Console.WriteLine("ok");
        }
    }
}
