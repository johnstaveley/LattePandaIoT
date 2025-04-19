using LattePanda.Firmata;
using System;
using System.Threading;

namespace LattePanda;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("LattePanda hardware integration");
        Arduino arduino = new Arduino();
        Console.WriteLine("Setup pins");
        arduino.PinMode(9, Arduino.INPUT);   // Motion Sensor
        arduino.PinMode(10, Arduino.OUTPUT); // Periodic LED
        arduino.PinMode(11, Arduino.OUTPUT); // Motion LED
        arduino.PinMode(1, Arduino.ANALOG);  // Hals eye
        arduino.WireBegin(200);
        Console.WriteLine("Starting loop");
        while (true)
        {
            Console.WriteLine("Red");
            arduino.DigitalWrite(10, Arduino.HIGH);
            var input = arduino.DigitalRead(9);
            if (input == Arduino.HIGH)
            {
                Console.WriteLine("Motion detected");
                arduino.DigitalWrite(11, Arduino.HIGH);
            }
            else
            {
                Console.WriteLine("No motion detected");
                arduino.DigitalWrite(11, Arduino.LOW);
            }
            Thread.Sleep(2000);
            Console.WriteLine("Green");
            arduino.DigitalWrite(10, Arduino.LOW);
            Thread.Sleep(2000);
        }
    }
}