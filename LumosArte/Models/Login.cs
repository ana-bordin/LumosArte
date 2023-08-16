using System.ComponentModel.DataAnnotations;

namespace LumosArte.Models
{
    public class Login
    {
        [Required]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Digite A Senha")]
        public string Senha { get; set; }
    }
}
