using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid TipoUsuarioId { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O tipo Usuario eh obrigatorio!")]
        public string? TituloTipoUsuario { get; set; }
    }
}
