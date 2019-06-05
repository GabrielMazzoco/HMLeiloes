using System;

namespace HorseMarket.Core.AuthAggregate.Dtos
{
    public class UserToCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
