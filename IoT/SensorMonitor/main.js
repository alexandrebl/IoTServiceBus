var request = require("request");
var mraa = require('mraa'); //require mraa

var ledProcess = new mraa.Gpio(2);
var ledTemp = new mraa.Gpio(3);
var ledLight = new mraa.Gpio(4);

var tempIO = new mraa.Aio(0);
var lightIO = new mraa.Aio(1);

ledProcess.dir(mraa.DIR_OUT); 
ledTemp.dir(mraa.DIR_OUT); 
ledLight.dir(mraa.DIR_OUT); 

 var sendSensorStatusRequest = {
    temperature : {
        celsius : "0",
        fahrenheit : "0",
        resistence : "0"
    },
    ldr : {
        intensity : "0"
    }
};

periodicActivity();

function periodicActivity()
{
    console.log("\n\nInit process");
    ledProcessOn();
    
    GetVersion();
    SendSensorStatus();
    
    ledProcessOff();
    
    setTimeout(periodicActivity, 5000);        
}

function GetVersion(){
    console.log("GetVersion Request");
    request("http://10.13.33.182:81/api/version/GetVersionAsync", function(error, response, body) {
        console.log(body);
    });
}

function SendSensorStatus(){
    console.log("SendSensorStatus Request");
    
    ReadTempSensor();
    ReadLightSensor();
    
    console.log(sendSensorStatusRequest);
    
    request({
      uri: "http://10.13.33.182:81/api/sensor/SetStatusAsync",
      method: "POST",
      json: true,
      body: sendSensorStatusRequest,
    }, function(error, response, body) {
        console.log("SendSensorStatusResponse success");        
    });
}

function ReadTempSensor() {
    
    ledTempOn();    
    var a = tempIO.read();
    
    var resistance = (1023 - a) * 10000 / a;        
    var celsius_temperature = 1 / (Math.log(resistance / 10000) / 3975 + 1 / 298.15) - 273.15;
    var fahrenheit_temperature = (celsius_temperature * (9 / 5)) + 32;
    
    sendSensorStatusRequest.temperature.celsius = celsius_temperature;
    sendSensorStatusRequest.temperature.fahrenheit = fahrenheit_temperature;
    sendSensorStatusRequest.temperature.resistence = resistance;
    
    ledTempOff();
}

function ReadLightSensor() {
    ledLightOn();
    
    var intensity = lightIO.read();
    
    sendSensorStatusRequest.ldr.intensity = intensity;
    
    ledLightOff();
}

function ledProcessOn(){
    ledProcess.write(1);
}

function ledProcessOff(){
    ledProcess.write(0);
}

function ledTempOn(){
    ledTemp.write(1);
}

function ledTempOff(){
    ledTemp.write(0);
}

function ledLightOn(){
    ledLight.write(1);
}

function ledLightOff(){
    ledLight.write(0);
}

