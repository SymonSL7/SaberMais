using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaberMais.Models
{
    [Table("Matriculas")]
    public class Matricula
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O curso é obrigatório.")]
        public int CursoId { get; set; }

        [ForeignKey("CursoId")]
        public Curso Curso { get; set; }

        [Required(ErrorMessage = "A data de matrícula é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Matrícula")]
        public DateTime DataMatricula { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Situação")]
        public bool Situacao { get; set; } = true; // true = Ativa, false = Não ativa

        [Required]
        [Display(Name = "Concluído")]
        public bool Concluido { get; set; } = false;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Conclusão")]
        public DateTime? DataConclusao { get; set; }
        public virtual ICollection<AulaConcluida> AulasConcluidas { get; set; } = new List<AulaConcluida>();
    }
}