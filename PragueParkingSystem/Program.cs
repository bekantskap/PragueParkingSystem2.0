using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;

namespace PragueParkingSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var m = new MainMenu();
            ReadData.DeserializeObject();
            m.MenuOptions();
        }
    }
}
