using System;
using System.Collections.Generic;
using Spectre.Console;
using System.Configuration;

namespace PragueParkingSystem
{
    class MainMenu
    {

        public char UserChoice
        { get; set; }
        public string VehicleChoice
        { get; set; }
        public int SpaceChoice
        { get; set; }
        public string LicenseChoice
        { get; set; }
        private int i, j;
        public string TimeStampOut
        { get; set; }


        public void MenuOptions()
        {
            do
            {
                Console.Clear();
                AnsiConsole.Render(
                    new Panel(new Text($"\nHello and Welcome to Prague City Parking valet service!\nWhat would you like to do?\n\n1. Park a Vehicle\n\n2. Move a Vehicle\n\n3. Remove a Vehicle\n\n4. Search for a Vehicle\n\n5. View map of the parking lot\n\n6. View the parking price list\n\n\nPress Q to quit the program\n ").Centered())
                            .Expand()
                            .SquareBorder()
                            .Header($"[red]Main Menu| |{DateTime.Now}[/]")
                            .HeaderAlignment(Justify.Center));
                UserChoice = char.ToLower(Console.ReadKey(true).KeyChar);

                switch (UserChoice)
                {
                    case '1':

                        AnsiConsole.Render(
                            new Panel(new Text($"\nWould you like to park an Mc or a Car:\n ").Centered())
                            .Expand()
                            .SquareBorder()
                            .Header("[red]Park A Vehicle[/]")
                            .HeaderAlignment(Justify.Center));
                        VehicleChoice = Console.ReadLine().ToLower();
                        switch (VehicleChoice)
                        {
                            case "mc":
                                Mc.ParkMC();
                                break;
                            case "car":
                                Car.ParkCar();
                                break;
                        }
                        break;
                    case '2':
                        MoveVehicle();
                        break;
                    case '3':
                        RemoveVehicle();
                        break;
                    case '4':
                        SearchVehicle();
                        break;
                    case '5':
                        ParkingLotMap();
                        break;
                    case '6':
                        PriceList();
                        break;
                }
            } while (!UserChoice.Equals('q'));
        }
        //////////// FLYTTA PÅ FORDON //////////////
        public void MoveVehicle()
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
        ////////////// SÖKA EFTER FORDON ///////////////
        public void SearchVehicle()
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

        ////////////// TA BORT FORDON ///////////////
        public void RemoveVehicle()
        {
            //Console.WriteLine("To check out vehicle please enter License number: ");

            AnsiConsole.Render(
               new Panel(new Text($"\nTo check out vehicle please enter License number: \n").Centered())
                   .Expand()
                   .SquareBorder()
                   .Header("[red]Check Out Menu[/]")
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
                        TimeStampOut = Vehicle.TimeCheckin();
                        AnsiConsole.Render(
                        new Panel(new Text($"Car was found at spot: {i}\nCheck out started at time {TimeStampOut}").Centered())
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
                        new Panel(new Text($"Mc was found at spot: {i}\nCheck out started at time {TimeStampOut}").Centered())
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

            foreach (ParkingList parkingSpot in spaces)
            {
                j = 0;
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 2)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        TimeStampOut = Vehicle.TimeCheckin();
                        AnsiConsole.Render(
                        new Panel(new Text($"Mc was found at spot: {i + 1}\nCheck out started at time {TimeStampOut}").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Check Out Menu[/]")
                        .HeaderAlignment(Justify.Center));
                        Console.ReadKey();
                        parkingSpot.parkingList.RemoveAt(j);
                        parkingSpot.availableSpace += 2;
                        ReadData.SerializeObject();
                        break;
                    }
                    j++;
                }
            }
        }
        ////////////// PARKERINGSÖVERBLICK ///////////////
        public void ParkingLotMap()
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

        public void PriceList()
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

    }
}





