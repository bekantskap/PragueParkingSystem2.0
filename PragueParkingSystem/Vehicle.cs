using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    public class Vehicle
    {
        public string LicensePlate
        { get; set; }

        public string VehicleType
        { get; set; }

        public int CarSize
        { get; set; }

        public string TimeStamp
        { get; set; }



        //public Vehicle()
        //{
        //    LicensePlate = Tools.GenerateLicensePlate();
        //    TimeStamp = DateTime.Now.ToString("HH:mm:ss MM/DD");
        //}
        public static string TimeCheckin()
        {
            return DateTime.Now.ToString("HH:mm:ss MM/dd");
        }






    }
}
