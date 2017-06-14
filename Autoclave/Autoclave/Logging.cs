using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Autoclave
{
    public class Logging
    {
        static MailAddress fromAddress = new MailAddress("tanner@shoutz.com", "Autoclave Automatic Log");
        static MailAddress toAddress = new MailAddress("autoclavelog@shoutz.com", "Autoclave Log Group");
        const string fromPassword = "sandst0ne";
        static string subject = "";
        static string body = "";

        private static bool NewUpdate = false;
        private static bool NeedsToWriteNewEntry = true;
        public static Headers LatestHeader;

        public static void CloseEntry()
        {
            NeedsToWriteNewEntry = true;
        }

        public static void ResetHeader()
        {
            LatestHeader = 0;
        }

        public static void UpdateLatestHeader(Headers header)
        {
            if(header > LatestHeader)
            {
                LatestHeader = header;
            }
        }

        static SmtpClient smtp;
        static System.Timers.Timer timer;
        public static void StartEmailLogLoop(int time)
        {
            timer = new System.Timers.Timer();
            timer.Interval = time;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (NewUpdate == false)
                return;

            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string specificpath = path + "\\Autoclave\\Log\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".log";

            if (File.Exists(specificpath))
            {
                string logContents = File.ReadAllText(specificpath);
                subject = "Autoclave Log: " + LatestHeader.ToString();
                body = "Autoclave's Log has been updated. The most severe header: " + LatestHeader.ToString();
                body += Environment.NewLine;
                body += logContents;

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                })
                {
                    try
                    {
                        smtp.Send(message);
                    }
                    catch
                    {
                        Logging.AddToLog(new string[]
                        {
                            "Autoclave could not send email notifications. There was an exception."
                        });
                    }
                }
            }

            NewUpdate = false;
        }

        public static void AddToLog(string[] lines)
        {
            NewUpdate = true;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string specificpath = path + "\\Autoclave\\Log\\" + DateTime.Now.ToShortDateString().Replace("/", "-") + ".log";

            if (!Directory.Exists(path + "\\Autoclave\\Log\\"))
            {
                Console.WriteLine("Log director does not exist. Creating...");
                Directory.CreateDirectory(path + "\\Autoclave\\Log\\");
            }
            if (!File.Exists(specificpath))
            {
                Console.WriteLine("Creating log for " + DateTime.Now.ToShortDateString() + ".log");
                File.WriteAllText(specificpath, "AUTOCLAVE Log File\n");
            }

            if(NeedsToWriteNewEntry)
                File.AppendAllText(specificpath, Environment.NewLine + "---------------" + Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine);
            NeedsToWriteNewEntry = false;
            File.AppendAllText(specificpath, Environment.NewLine);
            File.AppendAllLines(specificpath, lines);

        }
    }

    public enum Headers
    {
        LogUpdated,
        AutoclaveDetectedUpdate,
        ExceptionLogged
    }
}
