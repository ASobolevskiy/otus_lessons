using System;
using System.Collections.Generic;

namespace ShootEmUp.Providers
{
    interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}
