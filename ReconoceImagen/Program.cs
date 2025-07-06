namespace ReconoceImagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consumeACV = new ConsumeACV
            {
                SubscriptionKey = "1pbS9MFMMCOtsQWBPYyAuvUgJoRfMIE20k6hUlJBr1eVn3G6g4MIJQQJ99BGAC4f1cMXJ3w3AAAFACOGPCLC",
                ComputerVisionEndpoint = "https://reconoceimagen.cognitiveservices.azure.com/",
                Features = "tags,read,caption,denseCaptions,smartCrops,objects,people",
                ImageUrl = "https://www.ritmomedia.io/wp-content/uploads/2023/07/RM_CI_Mucho-texto-1-1229x1536.jpg"
            };

            //var resultEs = consumeACV.AnalyzeImage("es");
            Console.WriteLine("Resultado en español:");
            //Console.WriteLine(resultEs.ToString());

            var resultEn = consumeACV.AnalyzeImage();
            Console.WriteLine("Result in English:");
            Console.WriteLine(resultEn.ToString());

            Console.ReadLine();
        }
    }
}
