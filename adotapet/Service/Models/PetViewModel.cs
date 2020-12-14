using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Resumo { get; set; }

        public string Foto { get; set; }

        public IFormFile ArquivoFoto { get; set; }

        public string DataNascimento { get; set; }

        public string Raca { get; set; }

        public int IdOng { get; set; }
        public virtual Ong Ong { get; set; }

        public double Peso { get; set; }

        public bool Adotado { get; set; }

    }
}
