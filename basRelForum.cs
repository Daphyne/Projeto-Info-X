using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_INFOX.Models.Basicas
{
    public class basRelForum
    {
        public basRelForum()
        {
            this.MensagemForums = new List<basMensagemForum>();
        }
        //PK
        public int RelForumID { get; set; }
        
        public bool possui_ForumID { get; set; }
        public string mensagemResposta { get; set; }
      
        //Relacionamento
        public virtual ICollection<basMensagemForum> MensagemForums { get; set; }
    }
}