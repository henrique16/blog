using blogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogDAO.Interfaces
{
    public interface IUsuarioRepository : ICrudRepository<UsuarioModel>
    {
        int ExisteLogin(string pLogin);
        int ExisteEmail(string pEmail);
        UsuarioModel ObterPorKeyString(string pKey);
        int UpdateSenha(string pKey, string pSenha);
    }
}
