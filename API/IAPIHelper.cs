using Cook_Book_Client_Desktop_Library.Models;
using System.Threading.Tasks;

namespace Cook_Book_Client_Desktop_Library.API
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task<LoggedUser> GetLoggedUserData(string token);
    }
}