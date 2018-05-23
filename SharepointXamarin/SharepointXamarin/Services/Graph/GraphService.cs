using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Settings;
using SharepointXamarin.Constants;
using SharepointXamarin.Models;
using SharepointXamarin.Services.HttpConnector;
using SharepointXamarin.Services.SpecificPlataform;

namespace SharepointXamarin.Services.Graph
{
    public class GraphService : BaseWebService,  IGraphService 
    {
        public GraphService(IWebClientService conection) : base(conection)
        {
        }

        public async Task<MailResponse> GetMailInbox()
        {
            string url = WebServiceConstant.MailInbox;

            AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", Settings.GeneralSettings);
            conection.ClientHttp().DefaultRequestHeaders.Authorization = token;
            MailResponse response = new MailResponse();
            try
            {

                var result = await conection.ClientHttp().GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        response = JsonConvert.DeserializeObject<MailResponse>(content);
                        response.IsCorrect = true;
                        return response;
                    }
                }

              

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

            return response;
        }

        public async Task<PeopleResponse> GetPeople()
        {

            string url = WebServiceConstant.People;

            AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", Settings.GeneralSettings);
            conection.ClientHttp().DefaultRequestHeaders.Authorization = token;
            PeopleResponse response = new PeopleResponse();
            try
            {

                var result = await conection.ClientHttp().GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        response = JsonConvert.DeserializeObject<PeopleResponse>(content);
                        response.IsCorrect = true;
                        return response;
                    }
                }

                return response;

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

            return response;
        }

        public async Task<Profile> GetProfile()
        {
            string url = WebServiceConstant.Me;

            AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", Settings.GeneralSettings);
            conection.ClientHttp().DefaultRequestHeaders.Authorization = token;
            Profile response = new Profile();
            try
            {
               
                var result = await conection.ClientHttp().GetAsync(url);
                if (result.IsSuccessStatusCode){
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        response = JsonConvert.DeserializeObject<Profile>(content);
                        response.IsCorrect = true;
                        return response;
                    }
                }

                return response;

            }catch (Exception ex)
            {
                Crashes.TrackError(ex);
            }

             return response;
        }

        public async Task<bool> GetTokenAsync()
        {

            try
            {
               
                AuthenticationResult result = await App.PCA.AcquireTokenAsync(ConfigConstant.Scopes, App.UiParent);
                if(result!=null){
                    CrossSettings.Current.AddOrUpdateValue("settings", result.AccessToken);
                    App.Token = result.IdToken;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                return false;
            }
        

            return false;
        }


    }
}
