using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    class Bus : Vehicle
    {
        public Bus( int carSize, string licensePlate, string timeStamp)
        {
            CarSize = 16;
            VehicleType = "Bus";
        }
    }
}
