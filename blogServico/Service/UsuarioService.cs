using blogDAO.Interfaces;
using blogDAO.Repository;
using blogModel;
using blogServico.Interface;
using blogServico.Service.Validator.CadastroUsuario;
using blogServico.Service.Validator.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repo { get; set; }

        public ValidatorModel Insert(object pObj)
        {
            using (_repo = new UsuarioRepository())
            {
                ValidatorCadastroUsuario validator = new ValidatorCadastroUsuario();
                ValidatorModel resultValidator = validator.Validator((UsuarioModel)pObj);

                if (resultValidator.Result == true)
                {
                    bool result = _repo.Insert(pObj);

                    if (!result)
                    {
                        resultValidator.Mensagens.Add("Ocorreu alguma exceção, tente novamente (caso não funcione, ligue para o suporte)");
                        resultValidator.Result = false;
                        return resultValidator;
                    }

                    resultValidator.Mensagens.Add("Cadastro efetuado com sucesso");
                    return resultValidator;
                }
                else
                {
                    return resultValidator;
                }
            }
        }

        public bool DeletePorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public IList<UsuarioModel> Obter()
        {
            throw new NotImplementedException();
        }

        public object ObterPorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public int UpdateSenha(string pKey, string pSenha)
        {
            using (_repo = new UsuarioRepository())
            {
                return _repo.UpdateSenha(pKey, pSenha);
            }
        }

        public int ExisteLogin(string pLogin)
        {
            using (_repo = new UsuarioRepository())
            {
                return _repo.ExisteLogin(pLogin);
            }
        }

        public int ExisteEmail(string pEmail)
        {
            using (_repo = new UsuarioRepository())
            {
                return _repo.ExisteEmail(pEmail);
            }
        }

        public UsuarioModel ObterPorKeyString(string pKey)
        {
            using (_repo = new UsuarioRepository())
            {
                return _repo.ObterPorKeyString(pKey);
            }
        }

        public ValidatorModel Login(UsuarioModel pModel)
        {
            ValidatorLogin validatorLogin = new ValidatorLogin();
            ValidatorModel resultValidator = validatorLogin.Validator(pModel);

            if (resultValidator.Result == false)
                return resultValidator;
            else
            {
                resultValidator.Mensagens.Add("Bem Vindo =D");
                return resultValidator;
            }
        }
    }
}
