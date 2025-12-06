using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaberMais.Models
{
    [Table("Aulas")] 
    public class Aula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório nome da aula!")]
        [Display(Name = "Título da Aula")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório o conteúdo/descrição da aula!")]
        [Display(Name = "Conteúdo/Descrição")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "A duração é obrigatória")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public Status Status { get; set; }

        [StringLength(255)]
        public string? NomeArquivo { get; set; }

        [StringLength(500)]
        public string? CaminhoArquivo { get; set; }

        [StringLength(150)]
        public string? TipoArquivo { get; set; }

        public long? TamanhoArquivo { get; set; }

        [Required(ErrorMessage = "Obrigatório vincular a aula a um curso!")]
        public int CursoId { get; set; } 

        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }

        public virtual ICollection<Pergunta> Perguntas { get; set; } = new List<Pergunta>();
        public virtual ICollection<AulaConcluida> AulasConcluidas { get; set; } = new List<AulaConcluida>();
    }
}
