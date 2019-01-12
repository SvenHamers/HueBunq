# HueBunq
This is a early dev version for testing only !!


Collors your hue lights red and green based on withdrawal and deposit


Installation instructions:

Install dotnet core https://dotnet.microsoft.com/download

Generate HueUsername https://www.sitebase.be/generate-phillips-hue-api-token/

Generate a Bunq api key inside app

dotnet HueBunq.dll -setapi "<Bunqapikey>" -HueIp <HueBridgeIp> -HueSecret <HueSecret>

for testing with bunq sandbox envoirment use switch -UseSandbox
