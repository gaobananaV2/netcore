using System.Net.Mail;

namespace Peak.EStore.Infrastructure.Email
{
    public class SmtpService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {
            var message = new MailMessage { Subject = subject, Body = body };
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
    //<system.net>
    //<mailSettings>
    //<smtp>
    //<network host=”yoursmtpserver” port=”25”
    //userName=”username” password=”password”
    //defaultCredentials=”true” />
    //</smtp>
    //</mailSettings>
    //</system.net>
}