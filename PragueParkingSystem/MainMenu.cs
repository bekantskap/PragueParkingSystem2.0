using System;
using System.Collections.Generic;
using Spectre.Console;
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
                Console.WriteLine("Hello and Welcome to Prague City Parking valet service!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Park a Vehicle\n");
                Console.WriteLine("2. Move a Vehicle\n");
                Console.WriteLine("3. Remove a Vehicle\n");
                Console.WriteLine("4. Search for a Vehicle\n");
                Console.WriteLine("5. View map of the parking lot\n");
                Console.WriteLine("6. View the parking price list");
                Console.WriteLine("Press Q to quit the program\n");
                UserChoice = char.ToLower(Console.ReadKey(true).KeyChar);

                switch (UserChoice)
                {
                    case '1':

                        AnsiConsole.Render(
                            new Panel(new Text($"Would you like to park an Mc or a Car: ").LeftAligned())
                            .Expand()
                            .SquareBorder()
                            .Header("[red]Park A Vehicle[/]"));
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
                        //RemoveVehicle();
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

        /// <summary>
        /// ////////////////////
        /// </summary>
        public void MoveVehicle()
        {
            i = 0;
            j = 0;
            AnsiConsole.Render(
            new Panel(new Text($"To move a vehicle please enter license number: ").LeftAligned())
                .Expand()
                .SquareBorder()
                .Header("[red]Move A Vehicle[/]"));
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
                        new Panel(new Text($"{vehicle.VehicleType} with license number: {LicenseChoice} \nParked at spot: {i + 1}\nProceed to next step to choose a new spot").LeftAligned())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Move A Vehicle[/]"));
                        Console.ReadLine();
                        parkingSpot.parkingList.RemoveAt(0);
                        parkingSpot.availableSpace = 4;
                        ReadData.SerializeObject();
                        foreach (ParkingList pSpot in spaces)
                        {
                            AnsiConsole.Render(
                            new Panel(new Text($"Please choose a new parking spot: ").LeftAligned())
                            .Expand()
                            .SquareBorder()
                            .Header("[red]Move A Vehicle[/]"));
                            SpaceChoice = Int32.Parse(Console.ReadLine());
                            SpaceChoice -= 1;
                            pSpot.availableSpace = 0;
                            Car car = new Car(LicenseChoice, TimeStampOut);
                            ParkingSpaces.parkingSpots[SpaceChoice].parkingList.Add(car);
                            AnsiConsole.Render(
                            new Panel(new Text($"Car was parked at {SpaceChoice + 1}").LeftAligned())
                            .Expand()
                            .SquareBorder()
                            .Header("[green]Move A Vehicle[/]"));
                            Console.ReadLine();
                            ReadData.SerializeObject();
                            break;
                        }
                    }

                }

            }


            //foreach (ParkingList parkingSpot in spaces)
            //{
            //    //j = 0;
            //    foreach (Vehicle vehicle in parkingSpot.parkingList)
            //    {
            //        if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 2)
            //        {
            //            i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
            //            Console.WriteLine($"\tMc was found at spot: {i + 1}\n\tMoving vehicle");
            //            parkingSpot.parkingList.RemoveAt(j);
            //            parkingSpot.availableSpace += 2;
            //            break;
            //        }
            //        j++;

            //        Console.WriteLine("Currently available spaces: ");

            //        foreach (var item in ParkingSpaces.parkingSpots)
            //        {
            //            if (item.availableSpace >= 2)
            //            {
            //                Console.Write($"[{i + 1}]");
            //                j++;
            //                if (j == 5)
            //                {
            //                    Console.WriteLine(" ");
            //                    j = 0;
            //                }
            //            }
            //            i++;
            //            break;
            //        }
            //    }
            //}
            //Console.ReadKey();



        }


        ////////////// SÖKA EFTER FORDON ///////////////
        public void SearchVehicle()
        {

            AnsiConsole.Render(
            new Panel(new Text($"Please enter license number:").LeftAligned())
            .Expand()
            .SquareBorder()
            .Header("[red]Search for a parked vehicle[/]"));
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
                        new Panel(new Text($"{vehicle.VehicleType} with license number: {vehicle.LicensePlate} \nParked at spot: {i + 1}\nCheck in time: {vehicle.TimeStamp}").LeftAligned())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Search for a parked vehicle[/]"));
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
               new Panel(new Text($"To check out vehicle please enter License number: ").LeftAligned())
                   .Expand()
                   .SquareBorder()
                   .Header("[red]Check Out Menu[/]"));

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
                        new Panel(new Text($"Car was found at spot: {i + 1}\nCheck out started at time {TimeStampOut}").LeftAligned())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Check Out Menu[/]"));
                        //Console.WriteLine($"\tCar was found at spot: {i + 1}\n\tCheck out started at time {TimeStampOut}");
                        Console.ReadKey();
                        parkingSpot.parkingList.RemoveAt(0);
                        parkingSpot.availableSpace = 4;
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
                        new Panel(new Text($"Mc was found at spot: {i + 1}\nCheck out started at time {TimeStampOut}").LeftAligned())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Check Out Menu[/]"));
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
            int phouseSize = int.Parse(ConfigurationManager.AppSettings["ParkingHouseSize"]);
            int pSpotSize = int.Parse(ConfigurationManager.AppSettings["ParkingSpotSize"]);
        }

    }
}





