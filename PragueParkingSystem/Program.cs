using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using Spectre.Console;

namespace PragueParkingSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //////// LOGIN PAGE AND WELCOME ////////
            var content = new Markup(
                "[underline on blue]Logging in to system...[/] Password accepted\n\n\n\n" +
                "Press ENTER to continue").Centered();

            AnsiConsole.Render(
                new Panel(
                    new Panel(content)
                        .Border(BoxBorder.Rounded)));
            Console.ReadKey();

            AnsiConsole.Render(new FigletText("Prague").Centered().Color(Color.Red));
            Console.ReadKey();
            AnsiConsole.Render(new FigletText("City Parking").Centered().Color(Color.White));
            Console.ReadKey();
            AnsiConsole.Render(new FigletText("Vaschyskovska st.").RightAligned().Color(Color.Blue));
            Console.ReadKey();

            ///////// START PROGRAM AND READ FROM JSON /////////
            var m = new MainMenu();
            ReadData.DeserializeObject();
            m.MenuOptions();
        }
    }
}
