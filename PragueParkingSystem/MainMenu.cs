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
        public string TypeOfVehicle
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
                        ParkVehicle();

                        break;
                    //case '2':
                    //    SearchVehicle();
                    //    MoveVehicle();
                    //    break;
                    //case '3':
                    //    SearchVehicle();
                    //    RemoveVehicle();
                    //    break;
                    case '4':
                        SearchVehicle();
                        break;
                    case '5':
                        ParkingLotMap();
                        break;
                }
            } while (!UserChoice.Equals('q'));
        }


        public void ParkVehicle()
        {
            bool parkingChosen = false;
            while (parkingChosen == false)


            {
                Console.WriteLine("Would you like to park an Mc or Car?");
                TypeOfVehicle = Console.ReadLine().ToLower();

                if (TypeOfVehicle.Contains("mc"))
                {
                    //Mc mc = new Mc();
                    //Console.WriteLine($"This {mc.VehicleType} will take {mc.CarSize} spaces\n License Number is: {mc.LicensePlate}\n Time of check in: {mc.TimeStamp}");
                    //ParkingSpaces.parkingSpots.Add(new ParkingList { parkingList = { new Mc { LicensePlate = mc.LicensePlate, CarSize = mc.CarSize, VehicleType = mc.VehicleType, TimeStamp = Vehicle.TimeCheckin() } } });
                    var mc = new Mc();
                    
                    
                    parkingChosen = true;
                    Console.ReadKey();
                }

                else if (TypeOfVehicle.Contains("car"))
                {
                    Car car = new Car();
                    Console.WriteLine($"This {car.VehicleType} will take {car.CarSize} spaces\n License Number is: {car.LicensePlate}\n Time of check in: {car.TimeStamp}");
                    Console.ReadKey();
                    ParkingSpaces.parkingSpots.Add(new ParkingList { parkingList = { new Car { } } });
                    parkingChosen = true;
                }
                else
                {
                    Console.WriteLine("Please try again. Vehicle type not supported\n");
                }
            }
        }

        //public string ParkCar(string Registration, string parkingspot)
        //{
        //    int parkingSpot = int.Parse(parkingspot);
        //    ReadData.DeserializeObject();
        //    Car newCar = new Car();
        //    newCar.VehicleType = Vehicle.VehicleType.Car.ToString();
        //    newCar.regnumber = Registration;
        //    newCar.checkIn = DateTime.Now;
        //    ParkingSpaces.parkingSpots[parkingSpot - 1].VehicleInformation.Add(newCar);
        //    ParkingHouse.ParkingSpotInformation[parkingSpot - 1].SpaceRemaining = ParkingHouse.ParkingSpotInformation[parkingSpot - 1].SpaceRemaining - (int)VehicleSize.car;
        //    DataJSON.SerializeObject();
        //    return Registration;
        //}

        public void ParkVehicleInfo()
        {


        }
        public void SearchVehicle()
        {
            //Console.Write($"Enter the registration number of your desired vehicle: ");
            //string findAnswer = Console.ReadLine().ToLower();
            //var answer = ParkingSpaces..Where(answer => answer.parkingList == findAnswer);

            //foreach (var parkedCar in ParkingSpaces.parkingSpots)
            //{
            //    Console.WriteLine($"Car: {}:{author.Book}:{author.Price}");
            //}


        }

        public void RemoveVehicle()
        {

        }

        public void ParkingLotMap()
        {
            //var parkingList = new ParkingList();
            //foreach (var parkList in ParkingList.parkingList)
            //{
            //    Console.WriteLine(parkList);
            //}
            //Console.ReadKey();
        }


    }

}

