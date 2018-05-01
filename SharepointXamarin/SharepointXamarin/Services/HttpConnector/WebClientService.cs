using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SharepointXamarin.Services.HttpConnector
{
    public class WebClientService : IDisposable, IWebClientService
    {
        private HttpClient client;

        public NativeCookieHandler CookieContainer { get; set; }

        public WebClientService()
        {
            this.client = this.GenerateHttpClient();
        }

        private HttpClient GenerateHttpClient()
        {
            this.CookieContainer = new NativeCookieHandler();

            NativeMessageHandler httpClientHandler = new NativeMessageHandler(
                false,
                true,
                this.CookieContainer
            );

            return new HttpClient(httpClientHandler);

        }

        public HttpClient ClientHttp()
        {
            return this.client;
        }

        public void ClearCookieDefault()
        {
            this.client.DefaultRequestHeaders.Remove("Cookie");
        }


        public void Dispose()
        {
            this.client.Dispose();
        }
    }
}
