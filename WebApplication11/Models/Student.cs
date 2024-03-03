using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

        public int? Standard { get; set; }

        public string? Fathername { get; set; }

    }
}
