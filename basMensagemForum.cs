using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI_INFOX.Models.Basicas
{
    public class basMensagemForum
    {
        //PK
        public int ForumID { get; set; }
        
        public string titulo { get; set; }
        public DateTime horaCriacao { get; set; }
        public string mensagem { get; set; }

        //FK
        public int DisciplinaID { get; set; }
        public int matriculaAlunoID { get; set; }
        public int RelForumID { get; set; }
        
        //Relacionamentos
        public virtual basAluno Alunos { get; set; }
        //public virtual basDisciplina Disciplina { get; set; }
        //public virtual basRelForum RelForuns { get; set; }

    }
}
