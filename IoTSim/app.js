var request = require("request");

console.log("Do Get");
request("http://192.168.97.230:81/api/version/GetVersionAsync", function(error, response, body) {
  console.log(body);
});

console.log("------");

console.log("Do Post");
request({
  uri: "http://192.168.97.230:81/api/sensor/SetStatusAsync",
  method: "POST",
  json: true,
  body: {
    "Temperature" : {
        "celsius" : "21",
        "fahrenheit" : "67",
        "resistence" : 1233
    },
    "LDR" : {
        "Intensity" : "99"
    }
  }
}, function(error, response, body) {
  console.log(body);
});

console.log("------");
console.log("");