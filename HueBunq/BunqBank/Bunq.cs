using Bunq.Sdk.Context;
using Bunq.Sdk.Model.Generated.Endpoint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace HueBunq.BunqBank
{
    public class Bunq
    {
        private ApiContext _bunqApi;
        private Timer _bunqUpdateTimer;

        private decimal _previousAmmount;

        public int AccountId;
        private PHue.Hue _hueCommands;
        public Bunq(string ApiKey, bool SandBox,PHue.Hue hueCommands)
        {
            ApiEnvironmentType EnvType = ApiEnvironmentType.PRODUCTION;

            if (SandBox)
                EnvType = ApiEnvironmentType.SANDBOX;

            _bunqApi = ApiContext.Create(EnvType, ApiKey, "BunqHue");
            BunqContext.LoadApiContext(_bunqApi);
            //Every minut
            _bunqUpdateTimer = new System.Timers.Timer(10000);
            _hueCommands = hueCommands;
        }

        public void StartPolling()
        {
            MonetaryAccount.List().Value.ForEach(x => Console.WriteLine("AccountId: " + x.MonetaryAccountBank.Id + "  Description: " + x.MonetaryAccountBank.Description));
            Console.WriteLine("Type account id and press enter");
            AccountId = Int32.Parse(Console.ReadLine());

            _bunqUpdateTimer.Start();
            _bunqUpdateTimer.Elapsed += _bunqUpdateTimer_Elapsed;
        }

        private void _bunqUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Calculating differences");
            Difference();
        }

        private void Difference()
        {

            decimal CurrentAmount = GetAmmount();


            if (CurrentAmount > _previousAmmount)
                _hueCommands.Command("#0ed145");
            if (CurrentAmount == _previousAmmount)
                Console.WriteLine("");
            else
                _hueCommands.Command("#ff0b0b");


            _previousAmmount = CurrentAmount;
        }

        public decimal GetAmmount()
        {
           return decimal.Parse(MonetaryAccount.Get(AccountId).Value.MonetaryAccountBank.Balance.Value);
        }
    }
}
