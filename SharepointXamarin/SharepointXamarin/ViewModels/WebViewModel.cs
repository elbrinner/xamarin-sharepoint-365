using System;
using System.Threading.Tasks;
using SharepointXamarin.Models;
using SharepointXamarin.Services.Graph;
using SharepointXamarin.Services.Navigation;
using SharepointXamarin.ViewModels.Base;

namespace SharepointXamarin.ViewModels
{
    public class WebViewModel : BaseViewModel
    {
        private string myHtml;

        public WebViewModel(INavigationService navigationService, IGraphService graphWebService) : base(navigationService, graphWebService)
        {
            this.Title = "Correo";
        }

        public string MyHtml
        {
            get
            {
                return this.myHtml;
            }

            set
            {
                this.myHtml = value;
                this.OnPropertyChanged();
            }
        }

        public override async Task Appearing(object parameter)
        {

            if(parameter!=null){
                 Mail data = parameter as Mail;
                this.Title = data.Subject;
                this.MyHtml = data.Body.Content;

            }

        }

    }
}
