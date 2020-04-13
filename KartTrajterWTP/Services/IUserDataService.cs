using System;
using System.Threading.Tasks;

using KartTrajterWTP.ViewModels;

namespace KartTrajterWTP.Services
{
    public interface IUserDataService
    {
        event EventHandler<UserViewModel> UserDataUpdated;

        void Initialize();

        Task<UserViewModel> GetUserAsync();
    }
}
