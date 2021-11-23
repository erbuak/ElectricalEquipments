using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.ViewModels.Account
{
    public class UserRegisterViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [MaxLength(20, ErrorMessage = "Ad en fazla 20 karakter içerebilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [MaxLength(20, ErrorMessage = "Soyad en fazla 20 karakter içerebilir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [MaxLength(8, ErrorMessage = "Kullanıcı adı en fazla 8 karakter içerebilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail zorunludur.")]
        [MaxLength(50, ErrorMessage = "Mail en fazla 50 karakter içerebilir.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter içermelidir.")]
        public string Password { get; set; }
    }
}
