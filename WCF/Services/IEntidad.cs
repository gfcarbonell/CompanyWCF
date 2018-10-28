using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Services
{
    [ServiceContract]
    public interface IEntidad<T>where T:class
    {
        [OperationContract]
        T Save(T Entity);
        [OperationContract]
        T Update(T Entity);
        [OperationContract]
        ICollection<T> Get();
        [OperationContract]
        T GetById(int Id);
        [OperationContract]
        bool Delete(int Id);
    }
}
