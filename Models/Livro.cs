using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AT_SQL.Models
{
    public class Livro
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Capa { get; set; }
        [Required]
        [DisplayName("Título")]
        public string NomeLivro { get; set; }
        [Required]
        [DisplayName("Usuário")]
        [DefaultValue("NULL")]
        public string NomeUsuario { get; set; }
        [Required]
        [DisplayName("Email")]
        [DefaultValue("NULL")]
        public string EmailUsuario { get; set; }
        [Required]
        [DefaultValue("NULL")]
        public string Resenha { get; set; }        
    };
}
