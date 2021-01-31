using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PragueParkingSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ParkingSpaces.CreateSpaces();
            ReadData rd = new ReadData();
            rd.ReadWriteConfig();
            Console.WriteLine(ConfigSettings.ParkingHouseSize);
            Console.ReadKey();
            ReadData.DeserializeObject();
            var m = new MainMenu();
            m.MenuOptions();
        }
    }
}
