using blogModel;
using blogServico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Service.Validator.CadastroUsuario
{
    public class ValidatorCadastroUsuario
    {
        private IUsuarioService _svcUsuario;
        private IUsuarioService svcUsuario
        {
            get
            {
                if(_svcUsuario == null)
                    _svcUsuario = new UsuarioService();

                return _svcUsuario;
            }
        }

        public ValidatorModel Validator(UsuarioModel pModel)
        {
            ValidatorModel model = new ValidatorModel();

            //CAMPOS OBRIGATÓRIOS
            if (string.IsNullOrWhiteSpace(pModel.nome))
                model.Mensagens.Add("Preencha o campo Nome");

            if (string.IsNullOrWhiteSpace(pModel.login_id))
                model.Mensagens.Add("Preencha o campo Login");

            if (string.IsNullOrWhiteSpace(pModel.email))
                model.Mensagens.Add("Preencha o campo E-mail");

            if (string.IsNullOrWhiteSpace(pModel.senha))
                model.Mensagens.Add("Preencha o campo Senha");

            //VERIFICA SE LOGIN E EMAIL JÁ EXISTE NA BASE DE DADOS
            int resultLogin = svcUsuario.ExisteLogin(pModel.login_id);

            if (resultLogin == 1)
                model.Mensagens.Add("Login já existe, tente outro");

            if (resultLogin == 2)
                model.Mensagens.Add("Ocorreu alguma exceção, tente novamente (caso não funcione, ligue para o suporte)");

            int resultEmail = svcUsuario.ExisteEmail(pModel.email);

            if (resultEmail == 1)
                model.Mensagens.Add("E-mail já existe, tente outro");

            if (resultEmail == 2)
                model.Mensagens.Add("Ocorreu alguma exceção, tente novamente (caso não funcione, ligue para o suporte)");

            if (model.Mensagens.Count > 0)
                model.Result = false;
            else
                model.Result = true;


            return model;
        }
    }
}
