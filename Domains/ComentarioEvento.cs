using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioEventoId { get; set; }

        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "a descricao eh obrigatoria!")]
        public string? Comentarios { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "a resposta eh obrigatorio!")]
        public bool? Exibe { get; set; }

        public Guid Evento { get; set; }
        [ForeignKey("EventoId")]
        public Evento? Eventos { get; set; }

        public Guid Usuario { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuario? Usuarios { get; set; }
    }
}
