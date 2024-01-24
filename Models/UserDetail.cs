using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class UserDetail
    {
        [Key]
        public string? Username { get; set; }

        public string? Pwd { get; set; }
    }
}
