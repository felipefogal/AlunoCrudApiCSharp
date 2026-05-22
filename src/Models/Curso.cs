using System.ComponentModel.DataAnnotations;

namespace AlunosCrudApiCSharp.src.Models
{
    public class Curso
    {
        [Key]
        public int? CursoId { get; set; }

        [Required]
        public String? Nome { get; set; }

        [Required]
        public String? Descricao { get; set; }
    }
}
