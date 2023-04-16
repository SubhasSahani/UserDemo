using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserDemo
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
    }
}