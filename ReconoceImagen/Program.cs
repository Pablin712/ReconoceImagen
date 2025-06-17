namespace ReconoceImagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consumeACV = new ConsumeACV
            {
                SubscriptionKey = "d1c3a31c3e5243e8af964c1c95a01cb4",
                ComputerVisionEndpoint = "https://computervisionutn2023pagado.cognitiveservices.azure.com",
                Features = "tags,read,caption,denseCaptions,smartCrops,objects,people",
                ImageUrl = "https://www.ritmomedia.io/wp-content/uploads/2023/07/RM_CI_Mucho-texto-1-1229x1536.jpg"
            };

            var result = consumeACV.AnalyzeImage();

            Console.WriteLine(result.ToString());

            Console.ReadLine();
        }
    }
}
