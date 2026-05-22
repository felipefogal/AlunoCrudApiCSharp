using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunosCrudApiCSharp.src.Models
{
    public class Aluno
    {
        [Key]
        public int? AlunoId { get; set; }

        [Required]
        public String? Nome { get; set; }

        [Required]
        public String? Email { get; set; }

        [Required]
        public String? Endereco { get; set; }

        [Required]
        public String? Telefone { get; set; }

        [Required]
        public String? Documento { get; set; }

        [Required]
        public String? RM { get; set; }

        [ForeignKey("Curso")]
        public int? CursoId { get; set; }

        public Curso? Curso { get; set; }
    }
}
