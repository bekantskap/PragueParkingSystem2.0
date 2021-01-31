using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            List<ParkingList> parkingListnum = ParkingSpaces.parkingSpots;
            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ParkingSpaces.CreateSpaces();
                //ParkingList parkingList = new ParkingList();
                //parkingList.parkingLotNumber = 0;
                //ParkingSpaces.parkingSpots.Add(parkingList);
            }

            foreach (ParkingList availableCarSpace in parkingListnum.ToList())
            {
                int parkingSpotNum = parkingListnum.Count;
                Console.WriteLine("Enter the License plate number of the car: ");
                string userInput = Console.ReadLine().ToUpper();
                Car car = new Car(userInput, Vehicle.TimeCheckin());
                ParkingList parkingList = new ParkingList();
                parkingList.parkingLotNumber = parkingSpotNum++;
                parkingList.parkingList.Add(car);
                ParkingSpaces.parkingSpots.Add(parkingList);
                Console.WriteLine($"\t{car.VehicleType} with license plate {userInput}\n\tParked at time: {car.TimeStamp}\n\tCar size{car.CarSize}");
                availableCarSpace.availableSpace = 0;
                //ReadData.SerializeObject();
                Console.ReadKey();
                break;
            }
        }




    }
}
