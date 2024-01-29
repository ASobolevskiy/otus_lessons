using ShootEmUp.DI;
using ShootEmUp.Providers;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ShootEmUp.Installers
{
    public abstract class BaseInstaller : MonoBehaviour,
        IGameListenerProvider,
        IServiceProvider,
        IInjectProvider
    {
        public virtual IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            for(int i = 0; i < fields.Length; i++)
            {
                if (fields[i].IsDefined(typeof(ListenerAttribute)) && fields[i].GetValue(this) is Listeners.IGameListener gameListener)
                    yield return gameListener;
            }
        }

        public virtual IEnumerable<(System.Type, object)> ProvideServices()
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            for (int i = 0; i < fields.Length; i++)
            {
                var attribute = fields[i].GetCustomAttribute<ServiceAttribute>();
                if(attribute != null)
                {
                    var type = attribute.Contract;
                    var service = fields[i].GetValue(this);
                    yield return (type, service);
                }
            }
        }

        public virtual void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            for (int i = 0; i < fields.Length; i++)
            {
                var target = fields[i].GetValue(this);
                DependencyInjector.Inject(target, serviceLocator);
            }
        }
    }
}
