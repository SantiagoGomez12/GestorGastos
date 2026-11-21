namespace GestorGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = "";

        public decimal Costo { get; set; }

        public string Categoria { get; set; } = "";

        public DateTime Fecha { get; set; }
    }
}
