using System;
using System.Threading.Tasks;

using KartTrajterWTP.Core.Models;

namespace KartTrajterWTP.Core.Services
{
    public interface IMicrosoftGraphService
    {
        Task<User> GetUserInfoAsync(string accessToken);

        Task<string> GetUserPhoto(string accessToken);
    }
}
