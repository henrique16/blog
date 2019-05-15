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
    public class BlogRepository : ConnectionDAO, IBlogRepository
    {
        public bool DeletePorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public bool Insert(object pObj)
        {
            throw new NotImplementedException();
        }

        public bool InsertListObject(IList<object> pListObj)
        {
            throw new NotImplementedException();
        }

        public IList<BlogModel> Obter()
        {
            IList<BlogModel> list = new List<BlogModel>();
            BlogModel model = new BlogModel();
            SqlCommand cmd = new SqlCommand()
            {
                Connection = conn,
                CommandText = $"select * from dbo.blog"
            };

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                model.id_blog = Convert.ToInt32(reader[0]);
                model.nome = reader[1].ToString();
                model.assunto = reader[2].ToString();
                model.id_usuario_adm = reader[3].ToString();

                list.Add(model);
            }
            reader.Close();

            return list;
        }

        public object ObterPorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public bool Update(object pObject)
        {
            throw new NotImplementedException();
        }

        public bool UpdateListObject(IList<object> pListObject)
        {
            throw new NotImplementedException();
        }
    }
}
