using System;

namespace SaG.Core
{
    public interface ICreatePluginExpression
    {
        void Use<TConcreteType>();

        void Use(Type concreteType);

        void Use(object instance);

        void Add<TConreteType>();

        void Add(Type conreteType);

        void Add(object instance); 
    }
}