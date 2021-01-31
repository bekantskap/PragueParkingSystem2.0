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
            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ParkingList parkingList = new ParkingList();
                parkingList.parkingLotNumber = 0;
                ParkingSpaces.parkingSpots.Add(parkingList);
            }
            foreach (ParkingList extraMc in parkingListnum.ToList())
            {

                if (extraMc.availableSpace >= 2)
                {
                    if (extraMc.availableSpace == 4 && extraMc.parkingLotNumber == 0)
                    {

                        int parkingSpotNum = parkingListnum.Count;
                        ParkingList parkingList = new ParkingList();
                        parkingList.parkingLotNumber = parkingSpotNum++;
                    }
                    Console.WriteLine("Enter the License plate number of the Mc: ");
                    string userInput = Console.ReadLine().ToUpper();
                    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                    extraMc.parkingList.Add(mc);
                    Console.WriteLine($"{mc.VehicleType} with license plate {userInput}\n\tParked at time: {mc.TimeStamp}\n\tCar size{mc.CarSize}");
                    extraMc.availableSpace = extraMc.availableSpace -2;
                    //ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }



                //else
                //{
                //    int parkingSpotNum = parkingListnum.Count;
                //    Console.WriteLine("Enter the License plate number of the Mc: ");
                //    string userInput = Console.ReadLine().ToUpper();
                //    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                //    ParkingList parkingList = new ParkingList();
                //    parkingList.parkingLotNumber = parkingSpotNum++;
                //    parkingList.parkingList.Add(mc);
                //    ParkingSpaces.parkingSpots.Add(parkingList);
                //    Console.WriteLine($"{mc.VehicleType} with license plate {userInput}\n\tParked at time: {mc.TimeStamp}\n\tCar size{mc.CarSize}");
                //    extraMc.availableSpace = 2;
                //    //ReadData.SerializeObject();
                //    Console.ReadKey();
                //    break;
                //}
            }

        }




    }
}

