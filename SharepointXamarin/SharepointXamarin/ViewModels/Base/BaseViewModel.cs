using SharepointXamarin.Services.Graph;
using SharepointXamarin.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharepointXamarin.ViewModels.Base
{
    public class BaseViewModel : BindableObject
    {
        protected readonly INavigationService navigationService;
        protected readonly IGraphService graphWebService;
        protected string title;
        protected bool isBusy;

        public BaseViewModel(INavigationService navigationService, IGraphService graphWebService)
        {
            this.navigationService = navigationService;
            this.graphWebService = graphWebService;
        }



        public virtual Task Appearing(object parameter)
        {
            return Task.FromResult(false);
        }

        /// <summary>
        /// Indicador si la aplicación está esperando el servicio
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                this.OnPropertyChanged();
            }
        }



        /// <summary>
        /// Titulo de la pantalla que se muestra en la parte superior de la aplicación
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
                this.OnPropertyChanged();
            }
        }
    }
}
