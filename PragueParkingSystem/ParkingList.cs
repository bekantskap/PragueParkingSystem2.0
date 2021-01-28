using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    public class ParkingList
    {
        public List<Vehicle> parkingList { get; set; } = new List<Vehicle>();

        public int parkingLotNumber { get; set; }

        public int availableSpace { get; set; }
    }
}
