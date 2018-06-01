using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreOdata.Models
{
    public class Type
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}