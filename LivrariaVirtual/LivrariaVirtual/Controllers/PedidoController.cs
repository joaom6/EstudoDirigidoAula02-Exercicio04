using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivrariaVirtual.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly LivrariaContexto _context;

        public PedidoController(LivrariaContexto context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetPedido")]
        public ActionResult<Pedido> GetById(long id)
        {
            var item = _context.Pedidos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Crea um novo item
        /// </summary>
        /// <param name="item">item desejado</param>
        /// <returns>Novo item criado</returns>
        /// <response code="201">Se o item for criado</response>
        /// <response code="400">Se o item é nulo null</response>            
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Create(Pedido item)
        {
            _context.Pedidos.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetPedido", new { id = item.Codigo }, item);
        }

        /// <summary>
        /// Atualiza o item desejado
        /// </summary>
        /// <param name="id">Código do Item</param>
        /// <param name="item">Item desejado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update(long id, Pedido item)
        {
            var todo = _context.Pedidos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.DataPedido = item.DataPedido;
            todo.DataEntrega = item.DataEntrega;
            todo.Situacao = item.Situacao;
            todo.LivroComprado = item.LivroComprado;
            todo.UsuarioComprador = item.UsuarioComprador;

            _context.Pedidos.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deleta o item desejado
        /// </summary>
        /// <param name="id">Código do Item</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Pedidos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
