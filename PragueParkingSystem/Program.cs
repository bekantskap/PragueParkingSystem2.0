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
            ReadData.DeserializeObject();
            //List<ParkingList> parkingListnum = ReadData.DeserializeObject();
            var m = new MainMenu();
            m.MenuOptions();
            
            
            
            
            
            
            
            //var readData = new ReadData();

            //var vehicleTest = new ParkingSpaces();
            //string JSONresult = JsonConvert.SerializeObject(vehicleTest);
            //string path = @"C:/Repos/ParkingList/pSpaces.json";

            //if (!File.Exists(path))
            //{
            //    using (var tw = new StreamWriter(path, true))
            //    {
            //        tw.WriteLine(JSONresult.ToString());
            //        tw.Close();
            //    }
            //}
            //else if (!File.Exists(path))
            //{
            //    using (var tw = new StreamWriter(path, true))
            //    {
            //        tw.WriteLine(JSONresult.ToString());
            //        tw.Close();
            //    }
            //}





        }
    }
}
