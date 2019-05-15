using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogDAO;
using blogDAO.Interfaces;
using blogDAO.Repository;
using blogModel;
using blogServico;
using blogServico.Interface;
using blogServico.Service;

namespace Principal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUsuarioService svcU = new UsuarioService();

            bool result = svcU.UpdateSenha("gabriel16", "123");

            //IList<string> result = svcU.Login(new UsuarioModel() { login_id = "gabriel16", senha = "100" });


            //IUsuarioService service = new UsuarioService();

            //IList<string> result = service.Insert(model);

            //string mensagens = null;

            //foreach (string item in result)
            //{
            //    mensagens += $"{item}\n";
            //}

            //Console.Write(mensagens);
        }
    }
}
