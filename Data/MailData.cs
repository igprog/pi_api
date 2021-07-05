using System;
using System.Net;
using System.Net.Mail;
using api.Models;

namespace api.Data
{
    public class MailData : IMail
    {
        public Mail SendMail(Mail x)
        {
            string body = $@"Ime: {x.Name}
            Email: {x.Email}
            Poruka: {x.Msg}";
            x.Resp = SendMail(null, "Plan Ishrane - novi upit", body);
            return x;
        }

        private Response SendMail(string sendTo, string subject, string body)
        {
            try
            {
                string myEmail = "info@programprehrane.com";
                string myEmailName = "PLAN ISHRANE";
                string myServerHost = "mail.programprehrane.com";
                int myServerPort = 25;
                string myPassword = "Ipp123456$";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(myEmail, myEmailName);
                mail.To.Add(sendTo == null ? myEmail : sendTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(myServerHost, myServerPort);
                NetworkCredential Credentials = new NetworkCredential(myEmail, myPassword);
                smtp.Credentials = Credentials;
                smtp.Send(mail);
                Response r = new Response();
                r.IsSent = true;
                r.Msg = "Vaša poruka je uspešno poslata";
                r.Msg1 = "Odgovorićemo Vam u roku od 24h";
                return r;
            }
            catch (Exception e)
            {
                Response r = new Response();
                r.IsSent = false;
                r.Msg = e.Message;
                r.Msg1 = e.StackTrace;
                return r;
            }
        }
    }
}