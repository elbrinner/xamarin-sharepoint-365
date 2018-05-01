using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharepointXamarin.Pages;
using SharepointXamarin.Services.SpecificPlataform;
using SharepointXamarin.ViewModels;
using SharepointXamarin.ViewModels.Base;
using Xamarin.Forms;

namespace SharepointXamarin.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(HomeViewModel), typeof(HomePage)},
            { typeof(LoginViewModel), typeof(LoginPage)},

        };

        private void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            mappings.Add(typeof(LoginViewModel), typeof(LoginPage));


        }
        public  Task InitializeAsync()
        {
            var token = Settings.GeneralSettings; 
            if (!string.IsNullOrWhiteSpace(token))
            {
                return NavigateToAsync<HomeViewModel>();
            }
            else
            {
                return NavigateToAsync<LoginViewModel>();
            }
          
        }



        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }


        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return NavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return NavigateToAsync(viewModelType, null);
        }

        protected virtual async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            Xamarin.Forms.Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is LoginPage || page is HomePage)
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }
            else if (CurrentApplication.MainPage != null && CurrentApplication.MainPage.Navigation != null)
            {
                try
                {
                    await CurrentApplication.MainPage.Navigation.PushAsync(page);
                }
                catch (Exception ex)
                {
                    throw new Exception($"============ Navegation PushAsync error: " + ex.Message + "============");
                }
            }
        }

        protected Xamarin.Forms.Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Xamarin.Forms.Page page = Activator.CreateInstance(pageType) as Xamarin.Forms.Page;
            BaseViewModel viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;
           

            page.Appearing += async (object sender, EventArgs e) =>
            {
                await viewModel.Appearing(parameter);
            };

            return page;
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }


        public Task<bool> RemovePreviousPage()
        {
            try
            {
                if (CurrentApplication.MainPage.Navigation.NavigationStack.Count > 2)
                {
                    CurrentApplication.MainPage.Navigation.RemovePage(CurrentApplication.MainPage.Navigation.NavigationStack[CurrentApplication.MainPage.Navigation.NavigationStack.Count - 2]);
                }

            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


    }
}
