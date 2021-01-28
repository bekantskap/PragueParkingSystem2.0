using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    class Mc : Vehicle
    {
        public Mc()
        {
            VehicleType = "Mc";
            CarSize = 2;
        }

        public static void ParkMC()
        {
            Mc mc = new Mc();
            Console.WriteLine("Enter License plate number: ");
            string userInput = Console.ReadLine().ToUpper();
            ParkingSpaces.parkingSpots.Add(new ParkingList { parkingList = { new Mc { LicensePlate = userInput, CarSize = 2, VehicleType = "mc", TimeStamp = Vehicle.TimeCheckin() } } });
            Console.WriteLine($" with license plate {userInput} parked at time: {TimeCheckin()}, Car size");
            ReadData.SerializeObject();
            Console.ReadKey();
        }




    }
}

