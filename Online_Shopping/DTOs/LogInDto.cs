using Microsoft.Build.Framework;

namespace Online_Shopping.DTOs
{
    public class LogInDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
