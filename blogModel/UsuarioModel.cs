using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogModel
{
    public class UsuarioModel
    {
        public string login_id { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public int tipo { get; set; }
        public int logado { get; set; }

        public override string ToString()
        {
            return $"{nome} - {email}";
        }
    }
}
