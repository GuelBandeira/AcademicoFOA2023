﻿namespace Academico.Models
{
    public class AlunoDisciplina
    {
        public int? AlunoId {get; set;}
        public int? DisciplinaId { get; set;}
        public int Ano { get; set;}
        public int Semestre { get; set;}

        public Disciplina? Disciplina { get; set; }
        public Aluno? Aluno{ get; set; }

    }
}
