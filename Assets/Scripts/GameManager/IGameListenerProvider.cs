using System.Collections.Generic;

namespace ShootEmUp.Providers
{
    interface IGameListenerProvider
    {
        IEnumerable<Listeners.IGameListener> ProvideListeners();
    }
}
