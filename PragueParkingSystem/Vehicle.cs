using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using System.Configuration;

namespace PragueParkingSystem
{
    public class Vehicle
    {

        //////// FIELDS //////
        public string LicensePlate
        { get; set; }
        public string VehicleType
        { get; set; }
        public int CarSize
        { get; set; }
        public string TimeStamp
        { get; set; }
        private static string TimeStampOut
        { get; set; }
        private static int SpaceChoice
        { get; set; }
        private static string LicenseChoice
        { get; set; }
        
        private static int i, j;

        

        ////////////////// DATE TIME TO STRING //////////////////
        public static string TimeCheckin()
        {
            return DateTime.Now.ToString("HH:mm:ss MM/dd");
        }

        /////////////// MOVE VEHICLES ///////////////
        public static void MoveVehicle()
        {
            i = 0;
            j = 0;
            AnsiConsole.Render(
            new Panel(new Text($"\nTo move a vehicle please enter license number: \n").Centered())
                .Expand()
                .SquareBorder()
                .Header("[red]Move A Vehicle[/]")
                .HeaderAlignment(Justify.Center));
            LicenseChoice = Console.ReadLine().ToUpper();
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 4)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        AnsiConsole.Render(
                            new Panel(new Text($"{vehicle.VehicleType} with license number: {LicenseChoice} \nParked at spot: {i}\nProceed to next step to choose a new spot").Centered())
                                .Expand()
                                .SquareBorder()
                                .Header("[green]Move A Vehicle[/]")
                                .HeaderAlignment(Justify.Center));
                        Console.ReadLine();
                        parkingSpot.parkingList.RemoveAt(0);
                        AnsiConsole.Render(
                            new Panel(new Text($"\nPlease choose a new parking spot: \n").Centered())
                                .Expand()
                                .SquareBorder()
                                .Header("[red]Move A Vehicle[/]")
                                .HeaderAlignment(Justify.Center));
                        SpaceChoice = Int32.Parse(Console.ReadLine());
                        parkingSpot.parkingList.Insert(SpaceChoice, vehicle);
                        parkingSpot.availableSpace = 4;
                        ReadData.SerializeObject();
                        break;
                    }


                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 2)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        AnsiConsole.Render(
                            new Panel(new Text($"{vehicle.VehicleType} with license number: {LicenseChoice} \nParked at spot: {i}\nProceed to next step to choose a new spot").Centered())
                                .Expand()
                                .SquareBorder()
                                .Header("[green]Move A Vehicle[/]")
                                .HeaderAlignment(Justify.Center));
                        Console.ReadLine();
                        parkingSpot.parkingList.RemoveAt(0);
                        AnsiConsole.Render(
                            new Panel(new Text($"\nPlease choose a new parking spot: \n").Centered())
                                .Expand()
                                .SquareBorder()
                                .Header("[red]Move A Vehicle[/]")
                                .HeaderAlignment(Justify.Center));
                        SpaceChoice = Int32.Parse(Console.ReadLine());
                        parkingSpot.parkingList.Insert(SpaceChoice, vehicle);
                        parkingSpot.availableSpace += 2;
                        ReadData.SerializeObject();
                        break;
                    }

                }

            }

        }
        ////////////// SEARCH FOR VEHICLES /////////////
        public static void SearchVehicle()
        {

            AnsiConsole.Render(
            new Panel(new Text($"\nPlease enter license number:\n").Centered())
            .Expand()
            .SquareBorder()
            .Header("[red]Search for a parked vehicle[/]")
            .HeaderAlignment(Justify.Center));
            LicenseChoice = Console.ReadLine().ToUpper();
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate))
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        AnsiConsole.Render(
                        new Panel(new Text($"{vehicle.VehicleType} with license number: {vehicle.LicensePlate} \nParked at spot: {i + 1}\nCheck in time: {vehicle.TimeStamp}").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Search for a parked vehicle[/]")
                        .HeaderAlignment(Justify.Center));
                        Console.ReadLine();
                        break;
                    }
                }

            }

        }
        ////////////// CHECK OUT VEHICLES ///////////////
        public static void RemoveVehicle()
        {

            AnsiConsole.Render(
               new Panel(new Text($"\nTo check out vehicle please enter License number: \n").Centered())
                   .Expand()
                   .SquareBorder()
                   .Header("[red]Check Out Menu[/]")
                   .HeaderAlignment(Justify.Center));
            TimeStampOut = TimeCheckin();
            LicenseChoice = Console.ReadLine().ToUpper();
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 4)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        TimeStampOut = Vehicle.TimeCheckin();
                        AnsiConsole.Render(
                        new Panel(new Text($"Car was found at spot: {i}\nCheck in time:{vehicle.TimeStamp}\nCheck out time: {TimeStampOut}").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Check Out Menu[/]")
                        .HeaderAlignment(Justify.Center));
                        Console.ReadKey();
                        parkingSpot.parkingList.RemoveAt(0);
                        parkingSpot.availableSpace = 4;
                        ReadData.SerializeObject();
                        break;
                    }
                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 2)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        TimeStampOut = Vehicle.TimeCheckin();
                        AnsiConsole.Render(
                        new Panel(new Text($"Mc was found at spot: {i}\nCheck in time:{vehicle.TimeStamp}\nCheck out time: {TimeStampOut}").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Check Out Menu[/]")
                        .HeaderAlignment(Justify.Center));
                        Console.ReadKey();
                        parkingSpot.parkingList.RemoveAt(0);
                        parkingSpot.availableSpace += 2;
                        ReadData.SerializeObject();
                        break;
                    }
                }
            }
        }
        ////////////////// OVERVIEW OF THE PARKING LOT //////////////////
        public static void ParkingLotMap()
        {
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    AnsiConsole.Render(
                    new Panel(new Text($"\n|Parking No:{parkingSpot.parkingLotNumber}| |License Plate: {vehicle.LicensePlate}\n").Centered())
                   .Expand()
                   .AsciiBorder()
                   .Header($"[red]{vehicle.VehicleType}[/]")
                   .HeaderAlignment(Justify.Center));
                }
            }
            Console.ReadKey();
        }
        ////////////////// PRICE LIST //////////////////
        public static void PriceList()
        {
            float carPrice = float.Parse(ConfigurationManager.AppSettings["CarPrice"]);
            float mcPrice = float.Parse(ConfigurationManager.AppSettings["MCPrice"]);
            int freeTime = int.Parse(ConfigurationManager.AppSettings["FreeMinutes"]);

            AnsiConsole.Render(
                    new Panel(new Text($"\nAll prices listed are charged by the hour\nand payed with czech koruna\n\nCars: {carPrice}$.p/h\nMc: {mcPrice}$.p/h\n\nThe first {freeTime} minutes is always free.").Centered())
                   .Expand()
                   .AsciiBorder()
                   .Header($"[green]Price List[/]")
                   .HeaderAlignment(Justify.Center));
            Console.ReadKey();

        }
        ///////////////// CREATES PARKING LIST IF NOT EXISTING /////////////////
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
