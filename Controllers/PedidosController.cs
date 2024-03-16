using Microsoft.AspNetCore.Mvc;
using RevendedorAPI.Response;

namespace RevendedorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> _pedidos = new List<Pedido>
    {
        new Pedido
        {
            Id = 1,
            DataPedido = DateTime.Now,
            Itens = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Descricao = "Descrição para Produto 1", Preco = 10.00m },
                new Produto { Id = 2, Nome = "Produto 2", Descricao = "Descrição para Produto 2", Preco = 20.00m }
            }
        },
        new Pedido
        {
            Id = 2,
            DataPedido = DateTime.Now.AddDays(-1),
            Itens = new List<Produto>
            {
                new Produto { Id = 3, Nome = "Produto 3", Descricao = "Descrição para Produto 3", Preco = 30.00m }
            }
        }
    };

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            return _pedidos;
        }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return pedido;
        }

        [HttpPost]
        public IActionResult Post(Pedido pedido)
        {
            pedido.Id = _pedidos.Count + 1;
            _pedidos.Add(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Pedido pedido)
        {
            var pedidoExistente = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidoExistente == null)
            {
                return NotFound();
            }
            pedidoExistente.DataPedido = pedido.DataPedido;
            pedidoExistente.Itens = pedido.Itens;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            _pedidos.Remove(pedido);
            return NoContent();
        }
    }

}
