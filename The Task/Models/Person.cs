using System.ComponentModel.DataAnnotations;

namespace The_Task.Models
{
    public class Person
    {
        public int Id { get; set; }
        [StringLength(maximumLength:40, MinimumLength = 3)]
        public string Name { get; set; }
        [Required, Range(1,120)]
        public int Age { get; set; }
    }
}
