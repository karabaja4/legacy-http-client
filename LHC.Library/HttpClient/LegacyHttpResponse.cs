namespace LHC.Library.HttpClient
{
    public class LegacyHttpResponse
    {
        public int StatusCode { get; set; }
        public string ResponseText { get; set; }
        public bool IsSuccessStatusCode
        {
            get
            {
                return StatusCode >= 200 && StatusCode <= 299;
            }
        }
    }
}
