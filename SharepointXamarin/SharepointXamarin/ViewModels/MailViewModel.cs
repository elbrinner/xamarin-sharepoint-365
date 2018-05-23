using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using SharepointXamarin.Models;
using SharepointXamarin.Services.Graph;
using SharepointXamarin.Services.Navigation;
using SharepointXamarin.ViewModels.Base;

namespace SharepointXamarin.ViewModels
{
    public class MailViewModel : BaseViewModel
    {
        private List<Mail> listMail;
        private Mail selectedListMail;

        public MailViewModel(INavigationService navigationService, IGraphService graphWebService) : base(navigationService, graphWebService)
        {
            this.Title = "Bandeja de entrada";
            this.selectedListMail = null;

            Analytics.TrackEvent("Acceso a la bandeja de entrada");
        }

        public List<Mail> ListMail
        {
            get
            {
                return this.listMail;
            }

            set
            {
                this.listMail = value;
                this.OnPropertyChanged();
            }
        }

        public Mail SelectedListMail
        {
            get
            {
                return this.selectedListMail;
            }

            set
            {
                this.selectedListMail = value;
                if(value!=null){
                    this.LoadData(value);
                }
                this.OnPropertyChanged();
            }
        }

        private async void LoadData(Mail value)
        {
            Analytics.TrackEvent("Navegación para la pantalla de leer correo");
            await this.navigationService.NavigateToAsync<WebViewModel>(value);
        }

        public override async Task Appearing(object parameter)
        {

            if(ListMail!=null){
                return;
            }
            this.IsBusy = true;
            var response = await this.graphWebService.GetMailInbox();
            this.IsBusy = false;
            if (response.IsCorrect)
            {
                this.ListMail = response.Mail;
            }


        }
    }
}
