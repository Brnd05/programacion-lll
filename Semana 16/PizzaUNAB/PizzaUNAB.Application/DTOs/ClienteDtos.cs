namespace PizzaUNAB.Application.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? Telefono { get; set; }
    }

    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = "";
        public string? Telefono { get; set; }
    }

    public class ClienteUpdateDto
    { 
        public string Nombre { get; set; } = "";
        public string? Telefono { get; set; }
    }
}
