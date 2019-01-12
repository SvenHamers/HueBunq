using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.HSB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HueBunq.PHue
{
    public class Hue
    {
        private LocalHueClient _client;
        public Hue(string ip, string key)
        {
            _client = new LocalHueClient(ip);
            _client.Initialize(key);
        }

        public void Command(string hexCollor)
        {
            LightCommand Command = new LightCommand();
            Command.TurnOn();
            Command.SetColor(new RGBColor(hexCollor));
            Command.Alert = Alert.Multiple;
            _client.SendCommandAsync(Command);
        }

        private async Task<List<Light>> GetLights()
        {
           
            List<Light> Lights = new List<Light>();
            foreach (Light CurrentLigt in await _client.GetLightsAsync())
            {

                Lights.Add(CurrentLigt);
            }
            return Lights;
        }

        private RGBColor GetCollor(string hex)
        {
            return new RGBColor(hex);
        }
    }
}
