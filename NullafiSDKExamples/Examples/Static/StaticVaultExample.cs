using Nullafi;
using Nullafi.Domains.StaticVault;
using NullafiSDKExamples.Examples.Static.Managers;
using System;
using System.Threading.Tasks;

namespace NullafiSDKExamples.Examples.Static
{
    class StaticVaultExample
    {
        readonly Client client;

        public StaticVaultExample(Client client)
        {
            this.client = client;
        }

        public async Task Run()
        {

            /* Creating a new Static Vault
             *
             * IMPORTANT: Store your Vault Id and MasterKey, it will be necessary to retrieve this one
             */
            StaticVault created = await CreateStaticVault(client);
            var vaultId = created.VaultId;
            var vaultMasterKey = created.MasterKey;


            /*
             * Retrieving a existent Static Vault
             *
             * IMPORTANT: You will need your Id and MasterKey
             */
            StaticVault retrievedStaticVault = await RetrieveStaticVault(client, vaultId, vaultMasterKey);


            /*
             *  Running Static Vault Managers Examples
             */
            await new AddressExample(retrievedStaticVault).Run();
            await new DateOfBirthExample(retrievedStaticVault).Run();
            await new DriversLicenseExample(retrievedStaticVault).Run();
            await new FirstNameExample(retrievedStaticVault).Run();
            await new GenderExample(retrievedStaticVault).Run();
            await new GenericExample(retrievedStaticVault).Run();
            await new LastNameExample(retrievedStaticVault).Run();
            await new PassportExample(retrievedStaticVault).Run();
            await new PlaceOfBirthExample(retrievedStaticVault).Run();
            await new RaceExample(retrievedStaticVault).Run();
            await new RandomExample(retrievedStaticVault).Run();
            await new SsnExample(retrievedStaticVault).Run();
            await new TaxPayerExample(retrievedStaticVault).Run();
            await new VehicleRegistrationExample(retrievedStaticVault).Run();

            await DeleteStaticVault(client, vaultId);
        }

        private async Task<StaticVault> CreateStaticVault(Client client)
        {
            var name = "C# - Sample Static Vault Name";
            

            StaticVault staticVault = await client.CreateStaticVault(name, null);
            Console.WriteLine("**** StaticVaultExample.createStaticVault:");
            Console.WriteLine("-> Id: " + staticVault.VaultId);
            Console.WriteLine("-> Name: " + staticVault.VaultName);
            Console.WriteLine("-> MasterKey: " + staticVault.MasterKey);
            Console.WriteLine("\n");

            return staticVault;
        }

        private async Task<StaticVault> RetrieveStaticVault(Client client, String id, String masterKey)
        {
            StaticVault staticVault = await client.RetrieveStaticVault(id, masterKey);
            Console.WriteLine("**** StaticVaultExample.retrieveStaticVault:");
            Console.WriteLine("-> Id: " + staticVault.VaultId);
            Console.WriteLine("-> Name: " + staticVault.VaultName);
            Console.WriteLine("-> MasterKey: " + staticVault.MasterKey);
            Console.WriteLine("\n");

            return staticVault;
        }

        private async Task DeleteStaticVault(Client client, String id)
        {
            await client.DeleteStaticVault(id);
            Console.WriteLine("**** StaticVaultExample.deleteStaticVault:");
            Console.WriteLine("-> Id: " + id);
            Console.WriteLine("-> ok: true");
            Console.WriteLine("\n");
        }
    }
}
