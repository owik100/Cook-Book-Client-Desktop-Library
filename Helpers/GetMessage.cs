using Newtonsoft.Json;
using System.Net.Http;

namespace Cook_Book_Client_Desktop_Library.Helpers
{
    public static class GetMessage
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string ErrorMessageFromResponse(HttpResponseMessage response)
        {
            string output = "";
            try
            {
                var jsonMsg = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
                output = jsonMsg["message"];

            }
            catch (System.Exception ex)
            {
                _logger.Error("Got exception", ex);
                throw;
            }         
            return output;
        }
    }
}