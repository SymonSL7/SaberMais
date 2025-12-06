using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaberMais.Models
{
    [Table("AulasConcluidas")] 
    public class AulaConcluida
    {
        
        [Key]
        public string Id { get; set; }

        [Required]
        public int MatriculaId { get; set; }

        [ForeignKey("MatriculaId")]
        public virtual Matricula Matricula { get; set; } = null!;

        [Required]
        public int AulaId { get; set; }

        [ForeignKey("AulaId")]
        public virtual Aula Aula { get; set; } = null!;

        public bool Concluida { get; set; } = false;
        public DateTime? DataConclusao { get; set; }

    }
}