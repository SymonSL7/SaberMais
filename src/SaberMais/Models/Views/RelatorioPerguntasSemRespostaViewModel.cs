namespace SaberMais.Models
{
    public class RelatorioPerguntasSemRespostaViewModel
    {
        public int PerguntaId { get; set; }
        public string PerguntaConteudo { get; set; }
        public DateTime DataPergunta { get; set; }
        public int AulaId { get; set; }
        public string AulaTitulo { get; set; }
        public int CursoId { get; set; }
        public string CursoTitulo { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }
    }

}