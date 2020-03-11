using Cook_Book_Client_Desktop_Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cook_Book_Client_Desktop_Library.API
{
    public interface IRecipesEndPointAPI
    {
        Task<List<RecipeModel>> GetAllRecipesLoggedUser();
    }
}