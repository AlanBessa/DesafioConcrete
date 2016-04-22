using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS.Domain.SharedKernel.Interfaces
{
    public interface IContainer
    {
        T GetInstance<T>();
        object GetInstance(Type serviceType);
        IEnumerable<T> GetAllInstances<T>();
        IEnumerable<object> GetAllInstances(Type serviceType);
    }
}
