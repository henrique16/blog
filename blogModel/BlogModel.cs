using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogModel
{
    public class BlogModel
    {
        public int id_blog { get; set; }
        public string nome { get; set; }
        public string assunto { get; set; }
        public string id_usuario_adm { get; set; }
    }
}
