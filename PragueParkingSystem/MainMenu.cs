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
                                Mc. ParkMC();
                                break;
                            case "car":
                                Car.ParkCar();
                                break;
                        }
                        break;
                    case '2':
                        Vehicle.MoveVehicle();
                        break;
                    case '3':
                        Vehicle.RemoveVehicle();
                        break;
                    case '4':
                        Vehicle.SearchVehicle();
                        break;
                    case '5':
                        Vehicle.ParkingLotMap();
                        break;
                    case '6':
                        Vehicle.PriceList();
                        break;
                }
            } while (!UserChoice.Equals('q'));
        }
    }
}





