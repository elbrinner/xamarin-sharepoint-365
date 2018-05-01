using SharepointXamarin.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Lifetime;
using SharepointXamarin.Services.HttpConnector;
using SharepointXamarin.Services.Graph;

namespace SharepointXamarin.ViewModels.Base
{
    public class ViewModelLocator
    {

        readonly IUnityContainer container;
        private static readonly ViewModelLocator instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return instance;
            }
        }

        public ViewModelLocator()
        {
            container = new UnityContainer();

            container.RegisterType<INavigationService, NavigationService>();
            container.RegisterType<IWebClientService, WebClientService>();
            container.RegisterType<IGraphService, GraphService>();
            
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            container.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            container.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            container.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
