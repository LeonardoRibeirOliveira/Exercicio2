namespace Exercicio2.Models
{
    public class Artigos
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public ICollection<Data>? datas { get; set; } //Expressa a relação de 1 categoria para n Datas

    }
}
