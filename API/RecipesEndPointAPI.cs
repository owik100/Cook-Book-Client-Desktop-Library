using Cook_Book_Client_Desktop_Library.API.Interfaces;
using Cook_Book_Client_Desktop_Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<bool> InsertRecipe(RecipeModel recipeModel)
        {
            try
            {
                var multiForm = new MultipartFormDataContent();

                string ingredients = string.Join(";", recipeModel.Ingredients);

                if (recipeModel.ImagePath != null)
                {
                    FileStream fs = File.OpenRead(recipeModel.ImagePath);
                    multiForm.Add(new StreamContent(fs), "Image", Path.GetFileName(recipeModel.ImagePath));
                }

                multiForm.Add(new StringContent(recipeModel.Name), "Name");
                multiForm.Add(new StringContent(ingredients), "Ingredients");
                multiForm.Add(new StringContent(recipeModel.Instruction), "Instruction");

                using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsync("/api/Recipes", multiForm))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        return response.IsSuccessStatusCode;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> DeleteRecipe(string id)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync($"api/Recipes/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {

                    return response.IsSuccessStatusCode;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<bool> EditRecipe(RecipeModel recipeModel)
        {
            try
            {
                var multiForm = new MultipartFormDataContent();

                string ingredients = string.Join(";", recipeModel.Ingredients);

                if (recipeModel.ImagePath != null)
                {
                    FileStream fs = File.OpenRead(recipeModel.ImagePath);
                    multiForm.Add(new StreamContent(fs), "Image", Path.GetFileName(recipeModel.ImagePath));
                }

                multiForm.Add(new StringContent(recipeModel.Name), "Name");
                multiForm.Add(new StringContent(ingredients), "Ingredients");
                multiForm.Add(new StringContent(recipeModel.Instruction), "Instruction");
                multiForm.Add(new StringContent(recipeModel.RecipeId.ToString()), "RecipeId");

                using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsync($"/api/Recipes/{recipeModel.RecipeId.ToString()}", multiForm))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        return response.IsSuccessStatusCode;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
