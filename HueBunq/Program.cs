using Bunq.Sdk.Context;
using System;
using Bunq.Sdk.Model.Generated.Object;
using System.Collections.Generic;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace HueBunq
{
    class Program
    {

        Program()
        {


        }
        static void Main(string[] args)
        {
            string ApiKey = string.Empty;
            string HueApi = string.Empty;
            string HueSecret = string.Empty;
            bool Sandbox = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-setapi")
                {
                    ApiKey = args[i + 1];
                    i = i + 1;
                }
                if (args[i] == "-HueIp")
                {
                    HueApi = args[i + 1];
                    i = i + 1;
                }
                if (args[i] == "-HueSecret")
                {
                    HueSecret = args[i + 1];
                    i = i + 1;
                }
                if (args[i] == "-UseSandbox")
                {
                    Sandbox = true;
                }

            }

            Console.WriteLine(ApiKey);
            Console.WriteLine(HueApi);
            Console.WriteLine(HueSecret);

            BunqBank.Bunq BunqBank = new BunqBank.Bunq(ApiKey, Sandbox, new PHue.Hue(HueApi, HueSecret));
            BunqBank.StartPolling();



            Console.WriteLine("press any key to exit");
            Console.ReadLine();
        }


    }
}