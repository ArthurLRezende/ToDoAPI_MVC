using System.Globalization;

namespace WebApplication1.Models
{
    public class Tarefa
    {
        public Tarefa() { }
        public Tarefa(string name, DateOnly date, int id) 
        {
            Name = name;
            DateValue = date;
            Id_Usuario = id;
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateOnly DateValue { get; set; } = DateOnly.MinValue;
        public int Id_Usuario { get; set; }

    }
}
