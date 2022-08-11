using Api.Core.Configurations;

namespace Api.Extensions
{
    public static class EmailCollectionExtensions
    {
        public static void SetupEmail(this IServiceCollection services, SmtpOptions options)
        {
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates");

            var service = services
                            .AddFluentEmail(options.From)
                            .AddRazorRenderer(templatePath);

            if (!string.IsNullOrEmpty(options.Username))
            {
                service.AddSmtpSender(new System.Net.Mail.SmtpClient
                {
                    Host = options.Server,
                    Port = options.Port,
                    Credentials = new System.Net.NetworkCredential(options.Username, options.Password),
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false
                });
            }
            else
            {
                service.AddSmtpSender(options.Server, options.Port);
            }
        }
    }
}
