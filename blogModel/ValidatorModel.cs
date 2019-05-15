using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogModel
{
    public class ValidatorModel
    {
        public IList<string> Mensagens = new List<string>();
        public bool Result { get; set; }
    }
}
