using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    public class ParkingSpaces
    {

        /// <summary>
        /// Om det inte finns 4or eller 2 2or så är listan full. Kan vara ett annat sätt att limitera parkeringens storlek.
        /// Lägg mc som du gjorde i arrays, 2/4 etc och loopa igenom för att hitta första bästa lediga när du lägger in
        /// Checka in med en foor loop?
        /// sätt counter för att sätta storlek på lista 
        ///
        /// </summary>
        public static List<ParkingList> parkingSpots = new List<ParkingList>();
        public static int phouseSize = ConfigSettings.ParkingHouseSize;

        public static void CreateSpaces()
        {

            if (ParkingSpaces.parkingSpots.Count == 0)
            {
                ReadData.SerializeObject();

                for (int i = 0; i < phouseSize; i++)
                {
                    ParkingList pl = new ParkingList();
                    pl.parkingList = new List<Vehicle>();
                    pl.parkingLotNumber = i + 1;
                    pl.availableSpace = ConfigSettings.ParkingSpotSize;
                    parkingSpots.Add(pl);
                }
            }
        }

    }
}
