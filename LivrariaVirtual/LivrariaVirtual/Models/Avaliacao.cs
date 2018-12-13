using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaVirtual.Models
{
    public class Avaliacao
    {
        public long Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public Livro LivroAvaliado { get; set; }
    }
}
