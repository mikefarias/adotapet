using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Ong : Entidade
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome{ get; set; }

        [DisplayName("CNPJ")]
        public double Cnpj{ get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Contato")]
        public string Contato { get; set; }

        [DisplayName("Usuario")]
        [ForeignKey("Usuario")]
        public string IdUsuario { get; set; }

        public virtual IdentityUser Usuario { get; set; }

    }
}
