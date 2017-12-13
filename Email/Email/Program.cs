using System;
using System.Net.Mail;

namespace EMail_versenden
{
    class Program
    {
        static void Main(string[] args)
        {
            string ABSENDER = "";
            string PASSWORT = "";
            string EMPFÄNGER = "";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ABSENDER);
            mail.To.Add(EMPFÄNGER);
            mail.Subject = "BETREFF";
            mail.Body = "INHALT";
            //mail.IsBodyHtml = true; // Falls Body HTML Quellcode ist  

            SmtpClient client = new SmtpClient("smtp.live.com", 25);

            try
            {
                client.Credentials = new System.Net.NetworkCredential(ABSENDER, PASSWORT);

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
            Console.ReadKey();
        }
    }
}

