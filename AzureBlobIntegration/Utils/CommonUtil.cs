using AzureBlobIntegration.Models;
using Newtonsoft.Json;

namespace AzureBlobIntegration.Utils
{
    public static class CommonUtil
    {
        public static List<Property> ParseJsonData(string jsonData)
        {
            var result = JsonConvert.DeserializeObject<List<Property>>(jsonData);
            return result ?? new List<Property>();
        }
    }
}
