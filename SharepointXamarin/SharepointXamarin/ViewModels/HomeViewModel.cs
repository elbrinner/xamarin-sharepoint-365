using Plugin.Settings;
using SharepointXamarin.Models;
using SharepointXamarin.Services.Graph;
using SharepointXamarin.Services.Navigation;
using SharepointXamarin.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SharepointXamarin.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private List<People> listPeople;
        private Profile profile;



        public HomeViewModel(INavigationService navigationService, IGraphService graphWebService) : base(navigationService, graphWebService)
        {
            this.Title = "Mis datos";

        }

        private ICommand cerrarCommand;

        private ICommand correoCommand;


        /// <summary>
        /// Command que ejecuta la función de realizar el login
        /// </summary>
        public ICommand CerrarCommand
        {
            get { return cerrarCommand = cerrarCommand ?? new Command(DoCloseHandler); }
        }

        /// <summary>
        /// Command que ejecuta la función de realizar el login
        /// </summary>
        public ICommand CorreoCommand
        {
            get { return correoCommand = correoCommand ?? new Command(DoCorreoHandler); }
        }

        private async void DoCorreoHandler(object obj)
        {
            await this.navigationService.NavigateToAsync<MailViewModel>();
        }

        private async void DoCloseHandler(object obj)
        {
            CrossSettings.Current.AddOrUpdateValue("settings", string.Empty);

            foreach (var user in App.PCA.Users)
            {
                App.PCA.Remove(user);
            }

            await this.navigationService.NavigateToAsync<LoginViewModel>();
        }

        public List<People> ListPeople
        {
            get
            {
                return this.listPeople;
            }

            set
            {
                this.listPeople = value;
                this.OnPropertyChanged();
            }
        }

        public Profile Profile
        {
            get
            {
                return this.profile;
            }

            set
            {
                this.profile = value;
                this.OnPropertyChanged();
            }
        }


        private byte[] photo;

        public byte[] Photo
        {
            get
            {
                return this.photo;
            }

            set
            {
                this.photo = value;
                this.OnPropertyChanged();
            }
        }

        public override async Task Appearing(object parameter)
        {

            var ae = await this.graphWebService.GetMailInbox();
            this.IsBusy = true;
            this.Profile = await this.graphWebService.GetProfile();

            var response = await this.graphWebService.GetPeople();
            this.IsBusy = false;
            if(response.IsCorrect){
                this.ListPeople = response.People;   
            }


        }

    }
}
