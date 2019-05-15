using blogDAO.Interfaces;
using blogDAO.Repository;
using blogModel;
using blogServico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Service
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _repo { get; set; }

        BlogService()
        {
            _repo = new BlogRepository();
        }

        public ValidatorModel Insert(object pObj)
        {
            throw new NotImplementedException();
        }

        public bool InsertListObject(IList<object> pListObj)
        {
            throw new NotImplementedException();
        }

        public bool DeletePorKey(int pKey)
        {
            throw new NotImplementedException();
        }

        public IList<BlogModel> Obter()
        {
            throw new NotImplementedException();
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
