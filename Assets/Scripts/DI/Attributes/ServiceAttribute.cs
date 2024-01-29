using System;

namespace ShootEmUp.DI
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ServiceAttribute : Attribute
    {
        public readonly Type Contract;

        public ServiceAttribute(Type contract)
        {
            Contract = contract;
        }
    }
}
