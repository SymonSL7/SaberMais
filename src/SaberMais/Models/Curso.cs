using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaberMais.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório nome do curso!")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório descrição do curso!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Duração")]
        public int Duracao { get; set; }

        public Status Status { get; set; }

        [Display(Name = "Quantidade de inscritos")]
        public int QtdInscritos { get; set; } = 0; 

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]

        public Usuario Usuario { get; set; }


        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
        public virtual ICollection<Aula> Aulas { get; set; } = new List<Aula>();

    }
    public enum Status
    {
        Ativo,
        Inativo
    }
}
