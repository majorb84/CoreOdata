using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOdata.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public int TypeId { get; set; }
        public Model Model { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public bool IsAntique { get; set; }
    }
}
