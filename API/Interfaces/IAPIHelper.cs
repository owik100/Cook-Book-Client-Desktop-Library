using Cook_Book_Client_Desktop_Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cook_Book_Client_Desktop_Library.API.Interfaces
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoggedUser> GetLoggedUserData(string token);
        HttpClient ApiClient { get; }

        void LogOffUser();
    }
}