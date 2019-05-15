using blogModel;
using blogServico.Interface;
using blogServico.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace blogWeb.Home
{
    public partial class Home : System.Web.UI.Page
    {
        #region SERVICE

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            LimpaHiddenFields();

            UsuarioModel model = new UsuarioModel()
            {
                login_id = inputTextLogin.Value,
                senha = inputTextSenha.Value
            };

            ValidatorModel result = svcUsuario.Login(model);

            Result.Value = result.Result.ToString();

            foreach (string item in result.Mensagens)
            {
                Mensagens.Value += $"{item}\n";
            }

            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(btnConfirmar.GetType(), "mensagem", "Mensagens()", true);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            //CRIAR CLASSE QUE TEM A LISTA DE ERROS E UM BOOL RESULT

            LimpaHiddenFields();

            UsuarioModel model = new UsuarioModel()
            {
                nome = cadastroNome.Value,
                login_id = cadastroUsuario.Value,
                email = cadastroEmail.Value,
                senha = cadastroSenha.Value
            };

            ValidatorModel result = svcUsuario.Insert(model);

            Result.Value = result.Result.ToString();

            foreach (string item in result.Mensagens)
            {
                Mensagens.Value += $"{item}\n";
            }

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UsuarioModel));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, model);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);

            string json = sr.ReadToEnd();

            Objeto.Value = json;

            sr.Close();
            msObj.Close();

            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(btnConfirmar.GetType(), "mensagem", "CadastroOk()", true);
        }

        protected void LimpaHiddenFields()
        {
            Mensagens.Value = "";
            Result.Value = "";
            Objeto.Value = "";
        }
    }
}