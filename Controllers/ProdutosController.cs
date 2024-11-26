using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
[ApiController]
[Route("[controller]")]

public class ProdutoController : ControllerBase
{

private readonly AppDbContext _context;

public ProdutoController(AppDbContext context)
{
    _context = context;
}

    [HttpGet]
    public ActionResult<List<Produto>> Get()
    {
        return _context.Produtos.ToList();
    }
    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
       var produto = _context.Produtos.Find(id);
        
        if (produto == null)
        {
            return NotFound();
        }
        return produto;

    }
    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Produto produtoAtualizado)
    {
       var produto = _context.Produtos.Find(id);
        
        if (produto == null)
        {
            return NotFound();
        }
        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var produtoParaRemover = _context.Produtos.Find(id);
        if (produtoParaRemover == null)
        {
            return NotFound();
        }
        _context.Produtos.Remove(produtoParaRemover);
        _context.SaveChanges();
        return NoContent();




    }
}