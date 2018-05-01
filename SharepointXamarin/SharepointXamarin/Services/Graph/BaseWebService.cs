using System;
using SharepointXamarin.Services.HttpConnector;

namespace SharepointXamarin.Services.Graph
{
    public class BaseWebService
    {
        protected IWebClientService conection;
        public BaseWebService(IWebClientService conection)
        {
            this.conection = conection;
        }
    }
}
