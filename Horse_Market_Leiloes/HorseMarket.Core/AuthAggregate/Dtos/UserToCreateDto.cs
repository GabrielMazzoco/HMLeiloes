using System;
using System.ComponentModel.DataAnnotations;

namespace HorseMarket.Core.AuthAggregate.Dtos
{
    public class UserToCreateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Senha deve conter entre 6 e 10 caracteres.")]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
