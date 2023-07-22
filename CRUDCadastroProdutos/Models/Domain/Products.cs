namespace CRUDCadastroProdutos.Models.Domain
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
