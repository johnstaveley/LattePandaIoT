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
        arduino.PinMode(0, Arduino.INPUT);   // Switch
        arduino.PinMode(1, Arduino.OUTPUT); // Red LED
        arduino.PinMode(2, Arduino.OUTPUT); // Green LED
        Console.WriteLine("Starting loop:");
        while (true)
        {
            Console.Write(".");
            arduino.DigitalWrite(2, Arduino.HIGH);
            var input = arduino.DigitalRead(0);
            Thread.Sleep(100);
            if (input == Arduino.HIGH)
            {
                Console.WriteLine("");
                Console.WriteLine("Switch activated");
                arduino.DigitalWrite(2, Arduino.LOW);
                Thread.Sleep(100);
                arduino.DigitalWrite(1, Arduino.HIGH);
                Thread.Sleep(2000);
            }
            else
            {
                arduino.DigitalWrite(1, Arduino.LOW);
            }
            Thread.Sleep(1000);
            arduino.DigitalWrite(2, Arduino.LOW);
            Thread.Sleep(1000);
        }
    }
}