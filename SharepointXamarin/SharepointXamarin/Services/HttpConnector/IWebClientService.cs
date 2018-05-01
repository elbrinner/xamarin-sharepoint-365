using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SharepointXamarin.Services.HttpConnector
{
    public interface IWebClientService
    {
        HttpClient ClientHttp();

        void ClearCookieDefault();
    }
}
