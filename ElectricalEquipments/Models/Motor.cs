using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.Models
{
    public class Motor
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int Rpm { get; set; }
    }
}
