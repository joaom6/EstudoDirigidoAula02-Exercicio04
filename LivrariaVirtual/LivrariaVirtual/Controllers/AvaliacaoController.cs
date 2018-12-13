using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivrariaVirtual.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : Controller
    {
        private readonly LivrariaContexto _context;

        public AvaliacaoController(LivrariaContexto context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetAvaliacao")]
        public ActionResult<Avaliacao> GetById(long id)
        {
            var item = _context.Avaliacoes.Find(id);
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
        public ActionResult Create(Avaliacao item)
        {
            _context.Avaliacoes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAvaliacao", new { id = item.Codigo }, item);
        }

        /// <summary>
        /// Atualiza o item desejado
        /// </summary>
        /// <param name="id">Código do Item</param>
        /// <param name="item">Item desejado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update(long id, Avaliacao item)
        {
            var todo = _context.Avaliacoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Data = item.Data;
            todo.Descricao = item.Descricao;
            todo.LivroAvaliado = item.LivroAvaliado;

            _context.Avaliacoes.Update(todo);
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
            var todo = _context.Avaliacoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Avaliacoes.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
