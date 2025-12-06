namespace SaberMais.Models
{

    public class RelatorioProgressoViewModel
    {
        public int CursoId { get; set; }
        public string CursoTitulo { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
        public int TotalAulasAtivas { get; set; }
        public int AulasConcluidas { get; set; }
        public double PercentualConclusao { get; set; }
        public DateTime DataMatricula { get; set; }
    }

}