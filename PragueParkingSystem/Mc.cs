using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PragueParkingSystem
{
    class Mc : Vehicle
    {
        public Mc(string licensePlate, string timeStamp)
        {
            VehicleType = "Mc";
            CarSize = 2;
            LicensePlate = licensePlate;
            TimeStamp = timeStamp;
        }

        public static void ParkMC()
        {
            List<ParkingList> parkingListnum = ParkingSpaces.parkingSpots;
            foreach (ParkingList extraMc in parkingListnum.ToList())
            {
                if (extraMc.availableSpace == 1)
                {
                    Console.WriteLine("Enter License plate number: ");
                    string userInput = Console.ReadLine().ToUpper();
                    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                    extraMc.parkingList.Add(mc);
                    extraMc.availableSpace = 0;
                    ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }


                else
                {
                    int parkingSpotNum = parkingListnum.Count;
                    Console.WriteLine("Enter License plate number: ");
                    string userInput = Console.ReadLine().ToUpper();
                    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                    ParkingList parkingList = new ParkingList();
                    parkingList.parkingLotNumber = parkingSpotNum++;
                    parkingList.parkingList.Add(mc);
                    ParkingSpaces.parkingSpots.Add(parkingList);
                    Console.WriteLine($"{mc.VehicleType} with license plate {userInput} parked at time: {mc.TimeStamp}, Car size{mc.CarSize}");
                    extraMc.availableSpace = 1;
                    ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }
            }

        }




    }
}

