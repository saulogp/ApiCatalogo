using System.Collections.Generic;
using System.Linq;
using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get(){
            return _context.Produtos.ToList();
        }

        [HttpGet("{id}", Name= "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);

            return produto == null ? NotFound() : produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            if (!ModelState.IsValid) //isso não eh necessário caso tenha [ApiController] no topo
                return BadRequest();
            
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("ObterProduto", produto);
            
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (id == produto.ProdutoId)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            //var produto = _context.Produtos.Find(id); apenas se o id for PK e ele faz a busca na memória primeiro depois no banco
            if (produto == null)
                return NotFound();
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;

        }
    }
}