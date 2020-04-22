using CarRentals.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentals.DAL.Entities
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string LicencePlate { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public int Model { get; set; }
        [Required]
        public float OdometerValue { get; set; }
        [Required]
        public CarKind Kind { get; set; }


    }
}
