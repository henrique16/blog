using blogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Interface
{
    public interface IUsuarioService : ICrudService<UsuarioModel>
    {
        int ExisteLogin(string pLogin);
        int ExisteEmail(string pEmail);
        UsuarioModel ObterPorKeyString(string pKey);
        ValidatorModel Login(UsuarioModel pModel);

        bool UpdateSenha(string pKey, string pSenha);
    }
}
