using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Identity.Client;
using Plugin.Settings;
using SharepointXamarin.Constants;
using SharepointXamarin.Pages;
using SharepointXamarin.Services.Navigation;
using SharepointXamarin.Services.SpecificPlataform;
using SharepointXamarin.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharepointXamarin
{
	public partial class App : Application
	{
        public static PublicClientApplication PCA = null;

        public static string Username = string.Empty;

        public static string Token = string.Empty;

        public static UIParent UiParent = null;
        public App ()
		{
            App.PCA = new PublicClientApplication(ConfigConstant.IdAplication)
            {
                RedirectUri = $"msal{ConfigConstant.IdAplication}://auth"
            };

            MainPage = new LoginPage();

        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected async override void OnStart ()
		{
            base.OnStart();
            AppCenter.Start("android=5d9dede4-de8e-4996-992c-6aa65d1475d4;" + "ios=0551ae74-0da9-49f8-8bbd-5dcbf79a40e8; " + "uwp=56c69656-c78b-4bd6-b7b4-bc453e93d92d;", typeof(Analytics), typeof(Crashes));

            await InitNavigation();
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
