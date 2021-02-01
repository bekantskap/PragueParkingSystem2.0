using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Spectre.Console;
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
            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ParkingSpaces.parkingSpots = CreateSpaces();
            }
            foreach (ParkingList availableCarSpace in ParkingSpaces.parkingSpots)
            {

                if (availableCarSpace.availableSpace == 4)
                {
                    AnsiConsole.Render(
                    new Panel(new Text($"Please enter license number: ").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[red]Park A Car[/]")
                        .HeaderAlignment(Justify.Center));
                    string userInput = Console.ReadLine().ToUpper();
                    Car car = new Car(userInput, Vehicle.TimeCheckin());
                    availableCarSpace.parkingList.Add(car);
                    AnsiConsole.Render(
                    new Panel(new Text($"{car.VehicleType} with license plate {userInput}\nParked at time: {car.TimeStamp}\nSpace left: Parking spot is now full.").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Park A Car[/]")
                        .HeaderAlignment(Justify.Center));
                    availableCarSpace.availableSpace = 0;
                    ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }
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
                pl.parkingLotNumber = i+1 ;
                pl.availableSpace = pSpotSize;
                parkingListList.Add(pl);
            }
            return parkingListList;
        }


    }
}

