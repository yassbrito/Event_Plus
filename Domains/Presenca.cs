using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("Presenca")]
    [Index(nameof(Situacao), IsUnique = true)]
    public class Presenca
    {
        [Key]
        public Guid PresencaEventoId { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool? Situacao { get; set; }


        [Required(ErrorMessage = "Usuario Obrigatorio!")]
        public Guid UsauarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }


        [Required(ErrorMessage = "Evento Obrigatorio!")]
        public Guid EventoId { get; set; }
        [ForeignKey("EventoId")]
        public Evento? Evento { get; set; }
    }
}
