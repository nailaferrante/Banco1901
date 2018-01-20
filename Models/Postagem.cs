using System;

namespace projetoBanco1901.Models
{
       public class Postagem
    {
        public int Idpostagem { get; set; }
        public int Idtopico { get; set; }
        public int Idusuario { get; set; }
        public string Mensagem { get; set; }
        public DateTime Datapublicacao { get; set; }
        
    }
}