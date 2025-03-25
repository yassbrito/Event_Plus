using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid ComentarioEventoId { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "a descricao do comentario eh obrigatoria!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required]
        public bool? Exibe { get; set; }

        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        //ref.tabela Evento
        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }
    }
}
