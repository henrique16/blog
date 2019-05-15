using blogDAO.Interfaces;
using blogModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogDAO.Repository
{
    public class UsuarioRepository : ConnectionDAO, IUsuarioRepository
    {
        public bool DeletePorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object pObj)
        {
            try
            {
                UsuarioModel model = (UsuarioModel)pObj;
                model.tipo = 0;
                model.logado = 1;

                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = @"insert into usuario_adm values(@login, @senha, @nome, @email, @tipo, @logado)",
                };
                cmd.Parameters.AddWithValue("@login", model.login_id);
                cmd.Parameters.AddWithValue("@senha", model.senha);
                cmd.Parameters.AddWithValue("@nome", model.nome);
                cmd.Parameters.AddWithValue("@email", model.email);
                cmd.Parameters.AddWithValue("@tipo", model.tipo);
                cmd.Parameters.AddWithValue("@logado", model.logado);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                return false;
            }
            finally { }
        }

        public IList<UsuarioModel> Obter()
        {
            throw new NotImplementedException();
        }

        public int UpdateSenha(string pKey, string pSenha)
        {
            // retorno 0 = login nao existe -- retorno 1 = a senha digitada é igual a senha no banco -- retorno 2 = ok
            try
            {
                int resultExisteLogin = this.ExisteLogin(pKey);

                if (resultExisteLogin == 1)
                {
                    UsuarioModel model = this.ObterPorKeyString(pKey);

                    if (pSenha != model.senha)
                    {
                        SqlCommand cmd = new SqlCommand()
                        {
                            Connection = conn,
                            CommandType = System.Data.CommandType.Text,
                            CommandText = "update dbo.usuario_adm set senha = @senha where login_id = @login"
                        };

                        cmd.Parameters.AddWithValue("@senha", pSenha);
                        cmd.Parameters.AddWithValue("@login", pKey);

                        cmd.ExecuteNonQuery();
                    }
                    else return 1;
                }
                else return 0;

                return 2;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                return false;
            }
            finally { }
        }
        public int ExisteLogin(string pLogin)
        {
            // Retorno 0 = false ---- Retorno 1 = true ---- Retorno 2 = Exception

            object resultQuery;

            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "select count(*) from dbo.usuario_adm where login_id = @Login"
                };

                cmd.Parameters.AddWithValue("@Login", pLogin);

                SqlDataReader reader = cmd.ExecuteReader();
                resultQuery = reader;
                while (reader.Read())
                {
                    resultQuery = reader.GetSqlValue(0);
                }
                reader.Close();

                int result = Convert.ToInt32(resultQuery.ToString());

                if (result == 0)
                    return 0;
                else
                    return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                return 2;
            }
            finally { }
        }

        public int ExisteEmail(string pEmail)
        {
            // Retorno 0 = false ---- Retorno 1 = true ---- Retorno 2 = Exception

            object resultQuery;

            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "select count(*) from dbo.usuario_adm where email = @Email"
                };

                cmd.Parameters.AddWithValue("@Email", pEmail);

                var reader = cmd.ExecuteReader();
                resultQuery = reader;
                while (reader.Read())
                {
                    resultQuery = reader.GetSqlValue(0);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                return 2;
            }
            finally { }

            int result = Convert.ToInt32(resultQuery.ToString());

            if (result == 0)
                return 0;
            else
                return 1;
        }

        public UsuarioModel ObterPorKeyString(string pKey)
        {
            try
            {
                UsuarioModel model = new UsuarioModel();

                SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "select * from dbo.usuario_adm where login_id = @Login"
                };
                cmd.Parameters.AddWithValue("@Login", pKey);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    model.login_id = reader[0].ToString();
                    model.senha = reader[1].ToString();
                    model.nome = reader[2].ToString();
                    model.email = reader[3].ToString();
                    model.tipo = Convert.ToInt32(reader[4].ToString());
                }
                reader.Close();

                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
                return null;
            }
            finally { }
        }

        public object ObterPorKey(int pKey)
        {
            throw new NotImplementedException();
        }
    }
}
