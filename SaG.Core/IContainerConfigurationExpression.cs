using System;

namespace SaG.Core
{
    public interface IContainerConfigurationExpression
    {
        ICreatePluginExpression For<TPluginType>();

        ICreatePluginExpression For(Type pluginType);

        ICreatePluginExpression ForSingleton<TPluginType>();

        ICreatePluginExpression ForSingleton(Type pluginType);

        ICreatePluginExpression ForHttpContextScoped<TPluginType>();

        ICreatePluginExpression ForHttpContextScoped(Type pluginType);

        ICreatePluginExpression ForHybridHttpOrThreadLocalScoped<TPluginType>();

        ICreatePluginExpression ForHybridHttpOrThreadLocalScoped(Type pluginType);  
    }
}