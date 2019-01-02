using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.ServiceLocator
{
    public interface IServiceLocatorWPF
    {
        
        T GetService<T>();
        T GetServiceLazyLoading<T>();
        bool RegisterServiceType<T, C>(T service, C serviceChild, bool overwriteIfExists);
        bool RegisterServiceObject<T>(T service, bool overwriteIfExists);

    }
}
