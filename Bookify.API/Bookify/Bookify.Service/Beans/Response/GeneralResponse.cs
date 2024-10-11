namespace Bookify.Service.Beans.Response
{
    public class GeneralResponse
    {
        public Boolean Status { get; set; }
        public List<string>? Errors { get; set; }
    }
}
