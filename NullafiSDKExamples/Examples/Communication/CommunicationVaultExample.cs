using Nullafi;
using Nullafi.Domains.CommunicationVault;
using NullafiSDKExamples.Examples.Communication.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Communication
{
    class CommunicationVaultExample
    {
        readonly Client client;

        public CommunicationVaultExample(Client client)
        {
            this.client = client;
        }

        public async Task Run()
        {

            /* Creating a new Communication Vault
             *
             * IMPORTANT: Store your Vault Id and MasterKey, it will be necessary to retrieve this one
             */
            CommunicationVault created = await CreateCommunicationVault(client);
            var vaultId = created.VaultId;
            var vaultMasterKey = created.MasterKey;


            /*
             * Retrieving a existent Communication Vault
             *
             * IMPORTANT: You will need your Id and MasterKey
             */
            CommunicationVault retrievedCommunicationVault = await RetrieveCommunicationVault(client, vaultId, vaultMasterKey);


            /*
             *  Running Communication Vault Managers Examples
             */
            await new EmailExample(retrievedCommunicationVault).Run();

            await DeleteCommunicationVault(this.client, vaultId);
        }

        private async Task<CommunicationVault> CreateCommunicationVault(Client client)
        {
            var name = "C# - Sample Communication Vault Name";
            var tags = new List<string> { "communication", "vault" };
            

            CommunicationVault communicationVault = await client.CreateCommunicationVault(name, tags);
            Console.WriteLine("**** CommunicationVaultExample.createCommunicationVault:");
            Console.WriteLine("-> Id: " + communicationVault.VaultId);
            Console.WriteLine("-> Name: " + communicationVault.VaultName);
            Console.WriteLine("-> MasterKey: " + communicationVault.MasterKey);
            Console.WriteLine("\n");

            return communicationVault;
        }

        private async Task<CommunicationVault> RetrieveCommunicationVault(Client client, String id, String masterKey)
        {
            CommunicationVault communicationVault = await client.RetrieveCommunicationVault(id, masterKey);
            Console.WriteLine("**** CommunicationVaultExample.retrieveCommunicationVault:");
            Console.WriteLine("-> Id: " + communicationVault.VaultId);
            Console.WriteLine("-> Name: " + communicationVault.VaultName);
            Console.WriteLine("-> MasterKey: " + communicationVault.MasterKey);
            Console.WriteLine("\n");

            return communicationVault;
        }

        private async Task DeleteCommunicationVault(Client client, String id)
        {
            await client.DeleteCommunicationVault(id);
            Console.WriteLine("**** CommunicationVaultExample.deleteCommunicationVault:");
            Console.WriteLine("-> Id: " + id);
            Console.WriteLine("-> ok: true");
            Console.WriteLine("\n");
        }
    }
}
