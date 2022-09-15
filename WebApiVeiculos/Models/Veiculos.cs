namespace WebApiVeiculos.Models
{
    public class Veiculos
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int  Ano { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
        public double Valor { get; set; }

    }
}
