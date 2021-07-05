namespace api.Models
{
    public class Mail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Msg { get; set; }
        public Response Resp { get; set; }
    }

    public class Response
    {
        public bool IsSent { get; set; }
        public string Msg { get; set; }
        public string Msg1 { get; set; }
    }
}