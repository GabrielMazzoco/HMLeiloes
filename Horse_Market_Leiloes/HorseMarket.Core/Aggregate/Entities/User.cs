using System;
using System.Collections.Generic;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Core.Aggregate.Entities
{
    public class User : BaseEntity<User>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LasActive { get; set; }
        public bool Banido { get; set; }
        public bool Arrependido { get; set; }
        public int LocalidadeId { get; set; }

        public virtual ICollection<Cavalo> Cavalos { get; set; }
        public virtual Localidade Localidade { get; set; }
        public virtual Foto Foto { get; set; }
    }
}
