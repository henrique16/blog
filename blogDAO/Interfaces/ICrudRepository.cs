using System;
using System.Collections.Generic;
using blogModel;

namespace blogDAO.Interfaces
{
    public interface ICrudRepository<T> : IDisposable
    {
        bool Insert(object pObj);
        bool DeletePorKey(int pKey);
        IList<T> Obter();
        object ObterPorKey(int pKey);
    }
}
