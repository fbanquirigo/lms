using System;
using System.Collections.Generic;

namespace SaG.Core
{
    public interface IContainer
    {
        IEnumerable<TType> GetAllInstances<TType>();

        IEnumerable<Object> GetAllInstances(Type pluginType);

        object GetInstance(Type pluginType);

        TType GetInstance<TType>();

        object GetInstance(Type pluginType, Dictionary<string, object> arguments);

        TType GetInstance<TType>(Dictionary<string, object> arguments);

        object TryGetInstance(Type pluginType);

        TType TryGetInstance<TType>();

        void Initialize(Action<IContainerContext> context);

        void Configure(Action<IContainerConfigurationExpression> config);

        void Release(object instance);
    }
}