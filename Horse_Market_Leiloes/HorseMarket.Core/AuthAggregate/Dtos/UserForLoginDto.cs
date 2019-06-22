using System.ComponentModel.DataAnnotations;

namespace HorseMarket.Core.AuthAggregate.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
