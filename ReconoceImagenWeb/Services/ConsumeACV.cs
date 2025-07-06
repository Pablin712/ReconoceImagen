using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ReconoceImagenWeb.Models;
namespace ReconoceImagen
{
    public class ConsumeACV
    {
        private readonly string subscriptionKey = "1pbS9MFMMCOtsQWBPYyAuvUgJoRfMIE20k6hUlJBr1eVn3G6g4MIJQQJ99BGAC4f1cMXJ3w3AAAFACOGPCLC";
        private readonly string endpoint = "https://reconoceimagen.cognitiveservices.azure.com/";

        public async Task<ImageAnalysisResult> AnalyzeImage(string imageUrl, string language)
        {
            var uri = $"{endpoint}/computervision/imageanalysis:analyze?model-version=latest&language=en&api-version=2024-02-01&features={Features}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            var payload = new { url = imageUrl };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ImageAnalysisResult>(jsonResult);
            }
            else
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al analizar la imagen: {errorBody}");
            }
        }
    }
}
