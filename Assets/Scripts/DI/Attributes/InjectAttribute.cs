using JetBrains.Annotations;
using System;

namespace ShootEmUp.DI
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    class InjectAttribute : Attribute
    {
    }
}
