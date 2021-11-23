namespace RocketShoes.Entity
{
    public class Compra
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
    }
}
