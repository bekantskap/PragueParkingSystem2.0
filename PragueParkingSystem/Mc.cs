using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;

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
            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ParkingSpaces.parkingSpots = Car.CreateSpaces();
            }

            foreach (ParkingList extraMc in ParkingSpaces.parkingSpots)
            {

                if (extraMc.availableSpace == 4)
                {
                    AnsiConsole.Render(
                    new Panel(new Text($"\nPlease enter license number: \n").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[red]Park An MC[/]")
                        .HeaderAlignment(Justify.Center));
                    string userInput = Console.ReadLine().ToUpper();
                    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                    extraMc.parkingList.Add(mc);
                    AnsiConsole.Render(
                    new Panel(new Text($"{mc.VehicleType} with license plate {userInput}\nParked at time: {mc.TimeStamp}\nSpace left: Room for 1 more Mc.").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Move A Vehicle[/]")
                        .HeaderAlignment(Justify.Center));
                    extraMc.availableSpace = extraMc.availableSpace -= 2;
                    ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }
                if(extraMc.availableSpace == 2)
                {
                    AnsiConsole.Render(
                    new Panel(new Text($"\nPlease enter license number: \n").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[red]Park An MC[/]")
                        .HeaderAlignment(Justify.Center));
                    string userInput = Console.ReadLine().ToUpper();
                    Mc mc = new Mc(userInput, Vehicle.TimeCheckin());
                    extraMc.parkingList.Add(mc);
                    AnsiConsole.Render(
                    new Panel(new Text($"{mc.VehicleType} with license plate {userInput}\nParked at time: {mc.TimeStamp}\nSpace left: Parking space is now full.").Centered())
                        .Expand()
                        .SquareBorder()
                        .Header("[green]Move A Vehicle[/]")
                        .HeaderAlignment(Justify.Center));
                    extraMc.availableSpace = extraMc.availableSpace -= 2;
                    ReadData.SerializeObject();
                    Console.ReadKey();
                    break;
                }
            }

        }




    }
}

