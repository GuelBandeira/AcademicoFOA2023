namespace Academico.Models
{
    public class CursoDisciplina
    {
        public int CursoId { get; set; }
        public Curso? Curso { get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina? Disciplina { get; set; }
    }
}