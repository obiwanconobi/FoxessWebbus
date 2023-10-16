using FluentModbus;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ModbusTcpClient client = new ModbusTcpClient();

//ModbusClient client = new ModbusClient("10.10.10.11", 502);
client.Connect("10.10.10.11");
var unitIdentifier = 0xFF; // 0x00 and 0xFF are the defaults for TCP/IP-only Modbus devices.
var startingAddress = 31024;
var count = 1;

var shortData = client.ReadHoldingRegisters<float>(unitIdentifier, startingAddress, count);

foreach(var sss in shortData){
    var sd = sss;
    var innnt =  (int)Math.Ceiling(sd);
}

//var test = shortData.;
//Console.WriteLine($"Fist value is {test}");
//Console.WriteLine($"Fist value is {value}");
//var first = int.Parse(ReadOnlySpan(shortData.Slice(0, 1)));
// interpret data as float
var floatData = client.ReadHoldingRegisters<float>(unitIdentifier, startingAddress, count);

foreach(var ssds in floatData){
    var sds = ssds;
    int numInt = (int)Math.Ceiling(sds);
}
var firstValue = floatData[0];
var lastValue = floatData[floatData.Length - 1];

Console.WriteLine($"Fist value is {firstValue}");
Console.WriteLine($"Last value is {lastValue}");


