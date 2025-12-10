namespace PizzaUNAB.Application.DTOs
{
    public class PizzaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class PizzaCreateDto
    {
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class PizzaUpdateDto
    {
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
