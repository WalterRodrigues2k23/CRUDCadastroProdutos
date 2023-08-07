namespace CRUDCadastroProdutos.Models
{
    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
