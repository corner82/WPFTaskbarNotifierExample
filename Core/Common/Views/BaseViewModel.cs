using Core.Common.ServiceLocator;
using Core.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Views
{
    public class BaseViewModel : NotifyPropertyChangedBase
    {
        private   IUser user;

        /// <summary>
        /// Gets current user
        /// </summary>
        public IUser User
        {
            get {
                    if(user == null)
                    user = serviceLocator.GetService<IUser>();
                return user;
            }
            
        }



        ServiceLocatorSingleton serviceLocator;

        /// <summary>
        /// Gets the service locator 
        /// </summary>
        public ServiceLocatorSingleton ServiceLocator
        {
            get
            {
                if(serviceLocator == null)
                    return serviceLocator = ServiceLocatorSingleton.Instance;
                return serviceLocator;
            }
        }

        /// <summary>
        /// Gets a service from the service locator
        /// </summary>
        /// <typeparam name="T">The type of service to return</typeparam>
        /// <returns>Returns a service that was registered with the Type T</returns>
        public T GetService<T>()
        {
            return serviceLocator.GetService<T>();
        }

        static public T GetServiceStatic<T>()
        {
            //return serviceLocator.GetService<T>();
            return default(T);
        }

        public T GetServiceLazyLoading<T>()
        {
            return serviceLocator.GetServiceLazyLoading<T>();
        }
    }
}
