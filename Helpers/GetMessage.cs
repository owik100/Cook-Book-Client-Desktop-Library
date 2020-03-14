using Newtonsoft.Json;
using System.Net.Http;

namespace Cook_Book_Client_Desktop_Library.Helpers
{
    public static class GetMessage
    {
        public static string ErrorMessageFromResponse(HttpResponseMessage response)
        {
            string output = "";
            var jsonMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
            output = jsonMsg["message"];

            return output;
        }
    }
}