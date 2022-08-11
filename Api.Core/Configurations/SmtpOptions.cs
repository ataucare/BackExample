namespace Api.Core.Configurations
{
    public class SmtpOptions
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string> Bcc { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
