using blogDAO.Interfaces;
using blogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogServico.Interface
{
    public interface ICrudService<T>
    {
        ValidatorModel Insert(object pObj);
        bool DeletePorKey(int pKey);
        IList<T> Obter();
        object ObterPorKey(int pKey);
    }
}
