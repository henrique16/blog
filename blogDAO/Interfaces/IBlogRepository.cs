using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogModel;

namespace blogDAO.Interfaces
{
    public interface IBlogRepository : ICrudRepository<BlogModel>
    {
    }
}
