using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharepointXamarin.Models;

namespace SharepointXamarin.Services.Graph
{
    public interface IGraphService
    {

        Task<bool> GetTokenAsync();

        Task<Profile> GetProfile();

        Task<PeopleResponse> GetPeople();

        Task<MailResponse> GetMailInbox();

    }
}