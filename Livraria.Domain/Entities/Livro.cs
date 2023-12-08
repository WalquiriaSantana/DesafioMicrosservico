namespace Livraria.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int Quantidade { get; set; }
    }
}
