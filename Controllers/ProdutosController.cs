using Microsoft.AspNetCore.Mvc;
using RevendedorAPI.Response;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private static List<Produto> _produtos = new List<Produto>
    {
        new() { Id = 1, Nome = "Produto 1", Descricao = "Descrição para Produto 1", Preco = 10.00m },
        new() { Id = 2, Nome = "Produto 2", Descricao = "Descrição para Produto 2", Preco = 20.00m },
        new() { Id = 3, Nome = "Produto 3", Descricao = "Descrição para Produto 3", Preco = 30.00m },
        new() { Id = 3, Nome = "Produto 4", Descricao = "Descrição para Produto 4", Preco = 40.00m },
        new() { Id = 3, Nome = "Produto 5", Descricao = "Descrição para Produto 5", Preco = 50.00m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        return _produtos;
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        return produto;
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        produto.Id = _produtos.Count + 1;
        _produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Produto produto)
    {
        var produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);
        if (produtoExistente == null)
        {
            return NotFound();
        }
        produtoExistente.Nome = produto.Nome;
        produtoExistente.Descricao = produto.Descricao;
        produtoExistente.Preco = produto.Preco;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
        {
            return NotFound();
        }
        _produtos.Remove(produto);
        return NoContent();
    }
}
