using System;

namespace NullafiSDKExamples
{
    class Program
    {
        static readonly string API_KEY = "YOUR_API_KEY"; //Visit dashboard.nullafi.com to sign up and get your API Key if you don't have one.

        public static void Main(String[] args)
        {
            var examples = new Examples.Examples(API_KEY);
            examples.Run().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}
