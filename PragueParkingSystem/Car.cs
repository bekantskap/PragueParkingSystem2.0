using System;
using System.Collections.Generic;
using System.Text;

namespace PragueParkingSystem
{
    class Car : Vehicle
    { 

        public Car()
        {
            CarSize = 4;
            VehicleType = "Car";
        }

        public override string ToString()
        {
            return $"Car size: {this.CarSize} \t Vehicle Type: {this.VehicleType} \t License Number: {this.LicensePlate} \t Time parked: {this.TimeStamp}";
        }





    }
}
