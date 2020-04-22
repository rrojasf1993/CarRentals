using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentals.Common.DTO
{
    [Serializable]
    public class CarDTO:BaseDTO
    {
        public int Id { get; set; }
        public string LicencePlate { get; set; }
        public string Make { get; set; }
        public int Model { get; set; }
        public float OdometerValue { get; set; }
        public CarKind Kind { get; set; }
    }
}
