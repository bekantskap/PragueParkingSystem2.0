using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json.Converters;

namespace PragueParkingSystem
{
    class ReadData
    {
        string fileConfigPathJSON = @"C:/Repos/ParkingList/config.json";
        ConfigSettings newConfig = new ConfigSettings();
        public static void SerializeObject()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            string JSONresult = JsonConvert.SerializeObject(ParkingSpaces.parkingSpots, Formatting.Indented);
            string path = @"C:/Repos/ParkingList/pSpaces.json";
            using (var tw = new StreamWriter(path, false))
            {
                tw.Write(JSONresult);

            }
        }

        public static void DeserializeObject()
        {
            string json = File.ReadAllText(@"C:/Repos/ParkingList/pSpaces.json");
            ParkingSpaces.parkingSpots = JsonConvert.DeserializeObject<List<ParkingList>>(json);
        }

        public static void SerializeConfig()
        {
            JsonSerializer seralizer = new JsonSerializer();
            seralizer.Converters.Add(new JavaScriptDateTimeConverter());
            seralizer.NullValueHandling = NullValueHandling.Ignore;
            string fileConfigPathJSON = @"C:/Repos/ParkingList/config.json";
            var result = JsonConvert.SerializeObject(Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(fileConfigPathJSON))
            {
                writer.Write(result);
            }
        }

        public static void DeserializeConfig()
        {
            string fileConfigPathJSON = @"C:/Repos/ParkingList/config.json";
            string result = File.ReadAllText(fileConfigPathJSON);
            JsonConvert.DeserializeObject<ConfigSettings>(result);
        }









        //public void ReadWriteConfig()
        //{
        //    if (File.Exists(fileConfigPathJSON))
        //    {
        //        string result = File.ReadAllText(fileConfigPathJSON);
        //        newConfig = JsonConvert.DeserializeObject<ConfigSettings>(result);
        //    } 
        //    if(!File.Exists(fileConfigPathJSON))
        //    {
        //        JsonSerializer seralizer = new JsonSerializer();
        //        seralizer.Converters.Add(new JavaScriptDateTimeConverter());
        //        seralizer.NullValueHandling = NullValueHandling.Ignore;
        //        var result = JsonConvert.SerializeObject(newConfig, Formatting.Indented);
        //        using (StreamWriter writer = new StreamWriter(fileConfigPathJSON))
        //        {
        //            writer.Write(result);
        //        }
        //    }
        //}




    }
}
