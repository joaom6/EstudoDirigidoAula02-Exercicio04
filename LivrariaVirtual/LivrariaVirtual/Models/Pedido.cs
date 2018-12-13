using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaVirtual.Models
{
    public class Pedido
    {
        public long Codigo { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Situacao { get; set; }
        public Livro LivroComprado { get; set; }
        public Usuario UsuarioComprador { get; set; }
    }
}
