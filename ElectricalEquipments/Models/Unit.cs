using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ünite Adı zorunludur.")]
        [MaxLength(70, ErrorMessage = "Ünite Adı en fazla 70 karakter içerebilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ünite Kod Adı zorunludur.")]
        [MaxLength(10, ErrorMessage = "Ünite Kod Adı en fazla 10 karakter içerebilir.")]
        public string CodeName { get; set; }

        public virtual ICollection<Motor> Motors { get; set; }
    }
}
