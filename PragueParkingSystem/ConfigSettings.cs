using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PragueParkingSystem
{
    class ConfigSettings
    {
        public static int ParkingHouseSize { get; set; }
        public static int ParkingSpotSize { get; set; }
        public static int FreeMinutes { get; set; }
        public static float CarPrice { get; set; }
        public static float MCPrice { get; set; }
    }
}
