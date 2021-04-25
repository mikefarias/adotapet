using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    class Usuario : IdentityUser 
    {
        public Ong Ong { get; set; }

    }
}
