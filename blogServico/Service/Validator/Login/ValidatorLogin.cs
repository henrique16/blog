using blogModel;
using blogServico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Service.Validator.Login
{
    public class ValidatorLogin
    {
        private IUsuarioService _svcUsuario;
        private IUsuarioService svcUsuario
        {
            get
            {
                if (_svcUsuario == null)
                    _svcUsuario = new UsuarioService();

                return _svcUsuario;
            }
        }

        public ValidatorModel Validator(UsuarioModel pModel)
        {
            ValidatorModel model = new ValidatorModel();

            if (string.IsNullOrWhiteSpace(pModel.login_id))
                model.Mensagens.Add("Preencha o campo Login");

            if(string.IsNullOrWhiteSpace(pModel.senha))
                model.Mensagens.Add("Preencha o campo Senha");

            int result = svcUsuario.ExisteLogin(pModel.login_id);

            if (result == 2)
                model.Mensagens.Add("Ocorreu alguma exceção, tente novamente (Caso não funcione, ligue para o suporte)");

            if (result == 0)
                model.Mensagens.Add("Login inválido");

            if(result == 1)
            {
                UsuarioModel modelUsuario = svcUsuario.ObterPorKeyString(pModel.login_id);

                if (pModel.senha != modelUsuario.senha)
                    model.Mensagens.Add("Senha inválida");
            }

            if (model.Mensagens.Count > 0)
                model.Result = false;
            else
                model.Result = true;

            return model;
        }
    }
}
