using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconoceImagen
{
    internal class ConsumeACV
    {
        public string SubscriptionKey { get; set; }
        public string ComputerVisionEndpoint { get; set; }
        public string Features { get; set; }
        public string ImageUrl { get; set; }

        public ImageAnalisysResult AnalyzeImage()
        {
            using( var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
                var uri = $"{ComputerVisionEndpoint}/computervision/imageanalysis:analyze?model-version=latest&language=en&api-version=2024-02-01&features={Features}";

                var ojbectContent = new
                {
                    url = ImageUrl
                };
                var jsonContent = System.Text.Json.JsonSerializer.Serialize(ojbectContent);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = client.PostAsync(uri, content).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    return System.Text.Json.JsonSerializer.Deserialize<ImageAnalisysResult>(jsonResponse);
                }
                else
                {
                    throw new Exception($"Error: {response.ReasonPhrase}");
                }
            }
        }
    }
}
