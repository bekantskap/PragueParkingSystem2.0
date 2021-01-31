using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PragueParkingSystem
{
    class MainMenu
    {

        public char UserChoice
        { get; set; }
        public string VehicleChoice
        { get; set; }
        public string LicenseChoice
        { get; set; }
        private int i, j, answer;
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
                Console.WriteLine("5. View map of the parking lot.\n");
                Console.WriteLine("Press Q to quit the program\n");
                UserChoice = char.ToLower(Console.ReadKey(true).KeyChar);

                switch (UserChoice)
                {
                    case '1':

                        Console.WriteLine("Park an Mc or a Car?");
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
                        RemoveVehicle();
                        //MoveVehicle();
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
                }
            } while (!UserChoice.Equals('q'));
            ReadData.SerializeObject();
        }

        public void MoveVehicle()
        {
            //i = 0;
            //j = 0;
            //Console.WriteLine("Currently available spaces: ");
            //switch (answer)
            //{
            //    case 1:
            //        foreach (var item in ParkingSpaces.parkingSpots)
            //        {
            //            if (item.availableSpace >= 4)
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
            //        }
            //        break;

            //    case 2:
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
            //        }
            //        break;
            //}
        }

        ////////////// SÖKA EFTER FORDON ///////////////
        public void SearchVehicle()
        {
            Console.WriteLine("To search for a vehicle please enter License number: ");
            LicenseChoice = Console.ReadLine().ToUpper();
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate))
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        Console.WriteLine($"\t{vehicle.VehicleType} with license number: {vehicle.LicensePlate}\n\tParked at spot: {i + 1}\n\tCheck in time: {vehicle.TimeStamp}");
                        break;
                    }
                }
            }
            Console.ReadKey();

        }

        ////////////// TA BORT FORDON ///////////////
        public void RemoveVehicle()
        {
            Console.WriteLine("To check out vehicle please enter License number: ");
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
                        Console.WriteLine($"\tCar was found at spot: {i + 1}\n\tCheck out started at time {TimeStampOut}");
                        parkingSpot.parkingList.RemoveAt(0);
                        parkingSpot.availableSpace = 4;
                        break;
                    }
                }
            }
            Console.ReadKey();

            foreach (ParkingList parkingSpot in spaces)
            {
                j = 0;
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    if (LicenseChoice.Equals(vehicle.LicensePlate) && vehicle.CarSize == 2)
                    {
                        i = ParkingSpaces.parkingSpots.IndexOf(parkingSpot);
                        TimeStampOut = Vehicle.TimeCheckin();
                        Console.WriteLine($"\tMc was found at spot: {i + 1}\n\tCheck out started at time: {TimeStampOut}");
                        parkingSpot.parkingList.RemoveAt(j);
                        parkingSpot.availableSpace += 2;
                        break;
                    }
                    j++;
                }
            }
            Console.ReadKey();


        }
        ////////////// PARKERINGSÖVERBLICK ///////////////
        public void ParkingLotMap()
        {
            List<ParkingList> spaces = ParkingSpaces.parkingSpots;
            foreach (ParkingList parkingSpot in spaces)
            {
                foreach (Vehicle vehicle in parkingSpot.parkingList)
                {
                    Console.WriteLine($"|Parking No:{parkingSpot.parkingLotNumber}| {vehicle.VehicleType} |License Plate: {vehicle.LicensePlate}");
                }
            }
            Console.ReadKey();
        }



    }

}

