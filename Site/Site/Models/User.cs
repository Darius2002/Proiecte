using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Email {get; set;}
        public string Password { get; set; }
    }
}
