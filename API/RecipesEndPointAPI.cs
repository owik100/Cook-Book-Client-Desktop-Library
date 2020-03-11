using Cook_Book_Client_Desktop_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book_Client_Desktop_Library.API
{
    public class RecipesEndPointAPI : IRecipesEndPointAPI
    {
        private IAPIHelper _apiHelper;
        public RecipesEndPointAPI(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<RecipeModel>> GetAllRecipesLoggedUser()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Recipes/CurrentUserRecipes"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<RecipeModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
