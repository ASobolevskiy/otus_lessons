using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class PlayerInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider
    {
        private InputSystem inputSystem = new();

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return inputSystem;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(InputSystem), inputSystem);
        }
    }
}
