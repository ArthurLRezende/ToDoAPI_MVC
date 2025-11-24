namespace WebApplication1.Models
{
    public class Usuario
    {
        public Usuario() { }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public List<Tarefa> lista { get; set; }

    }
}
