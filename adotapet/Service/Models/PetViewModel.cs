using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Resumo")]
        public string Resumo { get; set; }
        [DisplayName("Foto")]
        public string Foto { get; set; }
        [DisplayName("Foto Perfil")]
        public IFormFile ArquivoFoto { get; set; }
        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }
        [DisplayName("Raça")]
        public string Raca { get; set; }
        [DisplayName("Ong")]
        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }
        [DisplayName("Peso")]
        public double Peso { get; set; }
        [DisplayName("É Adotado? ")]
        public bool Adotado { get; set; }

    }
}
