using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome do usuario é obrigatório")]
        public string? Nome { get; set; }


        [Column(TypeName = "VARCHAR(120)")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }


        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha é obrigatório")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 30 caracteres.")]
        public string? Senha { get; set; }

        //FK
        public Guid TipoUsuarioId { get; set; }
        [ForeignKey("TipoUsuarioId")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
