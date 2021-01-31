using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace PragueParkingSystem
{
    class Car : Vehicle
    {

        public Car(string licensePlate, string timeStamp)
        {
            VehicleType = "Car";
            CarSize = 4;
            LicensePlate = licensePlate;
            TimeStamp = timeStamp;
        }

        public static void ParkCar()
        {
            //List<ParkingList> parkingListnum = ParkingSpaces.parkingSpots;
            //if (ParkingSpaces.parkingSpots.Count == 0)
            //{

            //}
            Console.WriteLine(ParkingSpaces.parkingSpots.Count);
            Console.ReadLine();
            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ParkingSpaces.parkingSpots = CreateSpaces();
            }


            foreach (ParkingList availableCarSpace in ParkingSpaces.parkingSpots)
            {

                if (availableCarSpace.availableSpace == 4)
                {
                    Console.WriteLine("Enter the License plate number of the car: ");
                    string userInput = Console.ReadLine().ToUpper();
                    Car car = new Car(userInput, Vehicle.TimeCheckin());
                    availableCarSpace.parkingList.Add(car);
                    Console.WriteLine($"\t{car.VehicleType} with license plate {userInput}\n\tParked at time: {car.TimeStamp}\n\tCar size{car.CarSize}");
                    availableCarSpace.availableSpace = 0;
                    break;
                }

                //Console.WriteLine("Enter the License plate number of the car: ");
                //string userInput = Console.ReadLine().ToUpper();
                //Car car = new Car(userInput, Vehicle.TimeCheckin());
                //ParkingList parkingListList = new ParkingList();
                ////parkingList.parkingLotNumber = parkingSpotNum++;
                //parkingListList.parkingList.Add(car);
                //availableCarSpace.parkingList = ;
                //ParkingSpaces.parkingSpots.Add(parkingListList);
                //Console.WriteLine($"\t{car.VehicleType} with license plate {userInput}\n\tParked at time: {car.TimeStamp}\n\tCar size{car.CarSize}");
                //availableCarSpace.availableSpace = 0;
                //ReadData.SerializeObject();
                //Console.ReadKey();
                //break;
            }
        }


        public static List<ParkingList> CreateSpaces()
        {
            int phouseSize = int.Parse(ConfigurationManager.AppSettings["ParkingHouseSize"]);
            int pSpotSize = int.Parse(ConfigurationManager.AppSettings["ParkingSpotSize"]);

            List<ParkingList> parkingListList = new List<ParkingList>();

            for (int i = 0; i < phouseSize; i++)
            {
                ParkingList pl = new ParkingList();
                pl.parkingList = new List<Vehicle>();
                pl.parkingLotNumber = i + 1;
                pl.availableSpace = pSpotSize;
                parkingListList.Add(pl);
            }
            return parkingListList;
        }


    }
}

