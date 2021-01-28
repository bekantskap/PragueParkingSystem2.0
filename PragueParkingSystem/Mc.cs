using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    class Mc : Vehicle
    {
        public Mc()
        {
            CarSize = 2;
            VehicleType = "Mc";
        }

        public static void ParkMC()
        {
            Console.WriteLine("Enter License plate number: ");
            string userInput = Console.ReadLine().ToUpper();
            ParkingSpaces.parkingSpots.Add(new ParkingList { parkingList = { new Mc { LicensePlate = userInput, CarSize = 2, VehicleType = "mc", TimeStamp = Vehicle.TimeCheckin() } } });
        }




    }
}

