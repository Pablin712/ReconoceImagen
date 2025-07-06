namespace ReconoceImagenWeb.Models
{
    public class ImageAnalysisResult
    {
        public CaptionResult captionResult { get; set; }
    }

    public class CaptionResult
    {
        public List<Caption> values { get; set; }
    }

    public class Caption
    {
        public string text { get; set; }
        public float confidence { get; set; }
    }
}
