using System;
using System.Net.Mail;

namespace Communication
{
    public static class Email
    {
        public static void deliverPackage(string p_sender, string p_password, string p_recipient)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.live.com", 25);   

            mail.From = new MailAddress(p_sender);
            mail.To.Add(p_recipient);
            mail.Subject = "BETREFF";
            mail.Body = "INHALT";
            //mail.IsBodyHtml = true; // Falls Body HTML Quellcode ist  

            try
            {
                client.Credentials = new System.Net.NetworkCredential(p_sender, p_password);

                client.EnableSsl = true;

                client.Send(mail);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully delivered package...");
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to deliver package...\n\n{0}", ex.Message);
            }

            Console.ReadLine();
        }
    }
}
