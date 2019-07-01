using System;
using System.ComponentModel.DataAnnotations;

namespace HorseMarket.Core.Aggregate.Dtos
{
    public class LeilaoToCreateDto
    {
        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Fim { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve conter ao menos 5 caracteres!")]
        public string Nome { get; set; }

        [Required]
        public string Contato { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Descricao deve conter ao menos 10 caracteres!")]
        public string Descricao { get; set; }
    }
}
