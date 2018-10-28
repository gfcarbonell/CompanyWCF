using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Repository
{
    public interface IEntidad<T> where T : class
    {
        T Save(T t);
        T Update(T t);
        ICollection<T> Get();
        T GetById(int Id);
        bool Delete(int Id);
    }
}
