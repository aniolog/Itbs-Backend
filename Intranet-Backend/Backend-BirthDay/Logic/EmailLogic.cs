using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Backend_BirthDay.Logic
{
    class EmailLogic
    {
     

        static public Boolean BirthDayEmail(Model.snemple BirthDayEmployee) {
       
                using (MailMessage mail = new MailMessage())
                {
                    string smtpAddress = "smtp.mail.yahoo.com";
                    int portNumber = 587;
                    bool enableSSL = true;

                    string emailFrom = "anibal.lozano@itbscorp.com";
                    string password = "LG3523348!";
                    string emailTo = "anibal.lozano@itbscorp.com".ToLower();
                string subject = "Feliz Cumpleaños";
                    string body = System.IO.File.ReadAllText(LogicResource.TemplateUrl + LogicResource.BirthdayTemplate); 

                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.

                    //   mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                    //   mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        Thread.Sleep(1000);
                }
                }
                return true; 
        }

        static public Boolean PartnerEmail(Model.snemple BirthDayEmployee, Model.snemple NotBirthDayEmployee)
        {

            using (MailMessage mail = new MailMessage())
            {
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "anibal.lozano@itbscorp.com";
                string password = "LG3523348!";
                string emailTo = "anibal.lozano@itbscorp.com".ToLower();
                string subject = "Recordatorio";
                string body = System.IO.File.ReadAllText(LogicResource.TemplateUrl + LogicResource.NotificationTemplate);
                body = body.Replace("{sexo}", (BirthDayEmployee.sexo == "M" ? "nuestro compañero " : "nuestra compañera "));
                body = body.Replace("{nombre}", BirthDayEmployee.nombres.Split(' ')[0]);
                body = body.Replace("{apellido}", BirthDayEmployee.apellidos.Split(' ')[0]);

                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;


                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                    Thread.Sleep(1000);
                }
            }
            return true;
        }
    }
}
