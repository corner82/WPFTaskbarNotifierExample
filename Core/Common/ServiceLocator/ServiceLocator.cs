using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.ServiceLocator
{

    public class ServiceLocatorSingleton : IServiceLocatorWPF
    {
        private static ServiceLocatorSingleton instance;

        private Dictionary<Type, object> ServicesTypes { get; set; } = new Dictionary<Type, object>();
        private Dictionary<Type, object> InitialisedServices { get; set;  } = new Dictionary<Type, object>();

        private ServiceLocatorSingleton()
        {
            this.RegisterServiceTypes();
        }

        public static ServiceLocatorSingleton Instance {

            get
            {
                if (instance == null)
                    return instance = new ServiceLocatorSingleton();
                return instance;
            }
        }

        public T GetService<T>()
        {
            if(InitialisedServices.ContainsKey(typeof(T)))
                return (T)InitialisedServices[typeof(T)];
            throw new KeyNotFoundException();
        }

        public T GetServiceLazyLoading<T>()
        {
            if(this.ServicesTypes.ContainsKey(typeof(T)))
            {
                return (T)ServicesTypes.Where(x => x.Key == typeof(T)).FirstOrDefault().Value;
            } else
            {
                try
                {
                    ConstructorInfo constructor = ServicesTypes[typeof(T)].GetType().GetConstructor(new Type[0]);
                    Debug.Assert(constructor != null, "İlgili nesne için uygun yapılandırıcı metod bulunamamıştır " + typeof(T));

                    T service = (T)constructor.Invoke(null);
                    InitialisedServices.Add(typeof(T), service);
                    return service;

                } catch(KeyNotFoundException)
                {
                    throw new ApplicationException("İlgili servis kaydı bulunamamıştır");
                }
            }
        }

        public bool RegisterServiceObject<T>(T service,  bool overwriteIfExists = false)
        {
            lock(InitialisedServices)
            {
                if(!InitialisedServices.ContainsKey(typeof(T)))
                {
                    InitialisedServices.Add(typeof(T), service);
                    return true;
                } else if(overwriteIfExists)
                {
                    InitialisedServices[typeof(T)] = service;
                    return true;
                }
                return false;
            }
        }

        public bool RegisterServiceType<T, C>(T service, C childService, bool overwriteIfExists = false)
        {
            if(!ServicesTypes.ContainsKey(typeof(T)))
            {

                if(typeof(T).IsInstanceOfType(typeof(C))) {
                    ServicesTypes.Add(typeof(T), typeof(C));
                    return true;
                }
                throw new TypeAccessException("Service lazy load type exception");
            }
            else
            {
                if(overwriteIfExists)
                {
                    if (typeof(T).IsInstanceOfType(typeof(C)))
                    {
                        ServicesTypes.Add(typeof(T), typeof(C));
                        return true;
                    }
                    throw new TypeAccessException("Service lazy load type exception");
                }
            }
            return false;
        }

        private void RegisterServiceTypes()
        {

        }
    }
}
