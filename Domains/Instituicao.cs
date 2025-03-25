using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Event_Plus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid InstituicaoId { get; set; }


        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14)]

        public string? CNPJ { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
