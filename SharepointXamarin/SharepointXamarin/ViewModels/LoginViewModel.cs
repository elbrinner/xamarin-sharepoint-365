using Microsoft.AppCenter.Analytics;
using SharepointXamarin.Services.Graph;
using SharepointXamarin.Services.Navigation;
using SharepointXamarin.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SharepointXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService navigationService, IGraphService graphWebService) : base(navigationService, graphWebService)
        {
            this.Title = "Login";
            Analytics.TrackEvent("Acceso en la página de login");
        }



        private ICommand loginCommand;


        /// <summary>
        /// Command que ejecuta la función de realizar el login
        /// </summary>
        public ICommand LoginCommand
        {
            get { return loginCommand = loginCommand ?? new Command(DoLoginHandler); }
        }

        private async void DoLoginHandler(object obj)
        {
            try
            {
                bool result = await this.graphWebService.GetTokenAsync();
                if (result)
                {
                    Analytics.TrackEvent("Login - acceso ok");
                    await this.navigationService.NavigateToAsync<HomeViewModel>();
                }

                Analytics.TrackEvent("Login - acceso denegado");

            }
            catch (Exception ex)
            {
                Analytics.TrackEvent("Login - error: "+ ex.Message);
            }
           
        }
    }
}
