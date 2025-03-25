using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Plus.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid EventoId { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento eh obrigatorio!")]
        public string? EventoName { get; set; }


        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento eh obrigatorio!")]
        public DateTime DataEvento { get; set; }


        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descriçao do evento eh obrigatorio!")]
        public string? DescricaoEvento { get; set; }

        //ref.tabela TiposEventos
        public Guid IdTipoEvento { get; set; }

        public Guid TipoEvento { get; set; }

        [ForeignKey("TipoEventoId")]
        public TipoEvento? TiposEventos { get; set; }

        public Guid InstituicaoId { get; set; }
        [ForeignKey("InstituicaoId")]
        public Instituicao? Instituicao { get; set; }

        public Presenca? Presenca { get; set; }
    }
}
