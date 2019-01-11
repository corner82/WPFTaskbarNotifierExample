using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Factory
{
    public interface IFactoryUserAccess
    {
        void CheckUserAccess(System.Windows.DependencyObject sender);
    }
}
