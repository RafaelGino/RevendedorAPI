namespace RevendedorAPI.Response
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public List<Produto> Itens { get; set; }
    }
}
