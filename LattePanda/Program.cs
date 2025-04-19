using LattePanda.Firmata;
using System;
using System.Threading;

namespace LattePanda;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("LattePanda hardware integration demo");
        Arduino arduino = new Arduino();
        Console.WriteLine("Setting up pins");
        arduino.PinMode(9, Arduino.INPUT);   // Motion Sensor
        arduino.PinMode(10, Arduino.OUTPUT); // Red LED
        arduino.PinMode(11, Arduino.OUTPUT); // Green LED
        arduino.DigitalWrite(10, Arduino.HIGH);
        arduino.DigitalWrite(11, Arduino.HIGH);
        arduino.WireBegin(500);
        Console.WriteLine("Starting loop:");
        while (true)
        {
            Console.Write(".");
            arduino.DigitalWrite(11, Arduino.HIGH);
            arduino.DigitalWrite(11, Arduino.HIGH);
            var input = arduino.DigitalRead(9);
            if (input == Arduino.HIGH)
            {
                Console.WriteLine("");
                Console.WriteLine("Motion detected");
                arduino.DigitalWrite(10, Arduino.HIGH);
                arduino.DigitalWrite(10, Arduino.HIGH);
                Thread.Sleep(2000);
            }
            else
            {
                arduino.DigitalWrite(10, Arduino.LOW);
                arduino.DigitalWrite(10, Arduino.LOW);
            }
            Thread.Sleep(500);
            arduino.DigitalWrite(11, Arduino.LOW);
            arduino.DigitalWrite(11, Arduino.LOW);
            Thread.Sleep(500);
        }
    }
}