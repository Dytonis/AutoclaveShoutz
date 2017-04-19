using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace Launcher
{
    class Program
    {
        public static bool LaunchReady = false;

        static void Main(string[] args)
        {


            Console.WriteLine("Autoclave Launcher Version 1.0.0.157");
            Console.WriteLine("Copyright Shoutz, Inc. 2017");
            //Console.WriteLine("Password Required:");

            //if (!Console.ReadLine().ToUpper().Equals("072069"))
            //{
            //    Console.WriteLine("Unauthorized.");
            //    Console.Read();
            //    return;
            //}
            //
            //{

            if (args.Length <= 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Commands Available:");

                Console.WriteLine(" - \"launch\"          * Launch Autoclave");
                //Console.WriteLine(" - - \"-nogui\"         * Launch with command line only");
                Console.WriteLine(" - \"update\"          * Update Autoclave");
                Console.WriteLine(" - - \"-force\"        * Force the installation of the latest version");
                Console.WriteLine(" - - \"-launch\"       * Launch once completed");
                Console.WriteLine(" - \"check\"           * Check for updates");
                Console.WriteLine(" - \"help\"            * Print this text");
            }
            else
            {
                Console.WriteLine(args.Aggregate((i, j) => i + " " + j).ToString());
            }

            bool first = true;
            bool kill = false;
            while (!kill)
            {
                string command;
                string[] cmds;
                if (args.Length <= 0 || !first)
                {
                    command = Console.ReadLine();
                    cmds = command.Split(' ');
                }
                else
                {
                    command = args.Aggregate((i, j) => i + " " + j).ToString();
                    cmds = args;
                }

                if (cmds.Length > 0)
                {
                    if (cmds[0] == "launch")
                    {
                        if (File.Exists("Autoclave/Autoclave.exe"))
                        {
                            string current = Directory.GetCurrentDirectory();
                            System.Diagnostics.Process.Start(current + "/Autoclave/Autoclave.exe");
                        }
                        else
                            Console.WriteLine("Autoclave not installed. Please run \'update\'.");
                    }
                    else if (cmds[0] == "update")
                    {
                        bool c1 = false;
                        if (cmds.Length >= 2)
                        {
                            if (command.Contains("-force"))
                            {
                                DownloadAndCreateNewFiles();
                                c1 = true;
                            }
                            if (command.Contains("-launch"))
                            {
                                LaunchReady = true;
                                c1 = true;
                            }

                            if (!c1)
                            {
                                Console.WriteLine("> Usage: update -\'inner\'");

                                continue;
                            }
                        }

                        if (check())
                            DownloadAndCreateNewFiles();
                    }
                    else if (cmds[0] == "check")
                    {
                        check();
                    }
                    else if (cmds[0] == "kill")
                    {
                        kill = true;
                        continue;
                    }
                    else if (cmds[0] == "help")
                    {
                        Console.WriteLine("Commands Available:");

                        Console.WriteLine(" - \"launch\"          * Launch Autoclave");
                        //Console.WriteLine(" - - \"-nogui\"         * Launch with command line only");
                        Console.WriteLine(" - \"update\"          * Update Autoclave");
                        Console.WriteLine(" - - \"-force\"        * Force the installation of the latest version");
                        Console.WriteLine(" - \"check\"           * Check for updates");
                        Console.WriteLine(" - \"help\"            * Print this text");
                    }
                    else
                    {
                        Console.WriteLine("Command " + command + " not found. Consider running \'help\'.");
                    }

                    first = false;
                }
            }
            //}
        }

        public static int buildversion = -1;
        public static int versionLatest = -1;

        public static bool check()
        {
            try
            {
                if (File.Exists("Record.launcher"))
                {
                    try
                    {
                        buildversion = Convert.ToInt16(File.ReadAllText("Record.launcher"));
                    }
                    catch
                    {
                        Console.WriteLine("> Unable to read record.");
                    }
                }
                else
                {
                    Console.WriteLine("> Record does not exist. Creating...");
                    File.WriteAllText("Record.launcher", buildversion.ToString());
                }
            }
            catch
            {
                Console.WriteLine("> There was an error checking Record.launcher.");
            }

            try
            {
                using (WebClient wc = new WebClient())
                {
                    Console.WriteLine("> Checking latest version...");
                    wc.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("Dytonis" + ":" + "sandst0ne")));
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "ShoutzInc Autoclave Launcher");
                    string json = wc.DownloadString("https://api.github.com/repos/Dytonis/AutoclaveShoutz/releases");
                    ReleaseObject[] release = JsonConvert.DeserializeObject<ReleaseObject[]>(json);

                    try
                    {
                        versionLatest = Convert.ToInt16(release[0].tag_name);
                    }
                    catch
                    {
                        Console.WriteLine("> Unable to convert latest tag name to an integer. Could the tag name be missing/not in the right format?");
                        Launch();
                        return false;
                    }
                    Console.WriteLine("> Latest version is [" + versionLatest + "], current: [" + buildversion + "]");
                    if (versionLatest > buildversion && versionLatest >= 0)
                    {

                        if (versionLatest > buildversion)
                        {
                            Console.WriteLine("> The current installation is " + (versionLatest - buildversion) + " versions behind.");
                        }
                        Launch();
                        return true;
                    }
                    else
                    {
                        if (versionLatest < 0)
                            Console.WriteLine("> The version of the latest build could not be read.");
                        else
                            Console.WriteLine("> The current installation is up to date.");

                        Launch();
                        return false;
                    }
                }
            }
            catch
            {
                Console.WriteLine("> There was an error while downloading.");
                Launch();
                return false;
            }
        }

        public static void DownloadAndCreateNewFiles()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Console.WriteLine("> Getting...");
                    wc.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("Dytonis" + ":" + "sandst0ne")));
                    wc.Headers.Add(HttpRequestHeader.UserAgent, "ShoutzInc Autoclave Launcher");
                    string json = wc.DownloadString("https://api.github.com/repos/Dytonis/AutoclaveShoutz/releases");
                    ReleaseObject[] release = JsonConvert.DeserializeObject<ReleaseObject[]>(json);

                    Console.WriteLine("> Downloading " + release[0].assets[0].name);
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new Uri(release[0].assets[0].browser_download_url), "LatestBuild.zip");

                    try
                    {
                        buildversion = Convert.ToInt16(release[0].tag_name);
                    }
                    catch
                    {
                        Console.WriteLine("> Unable to convert latest tag name to an integer. Could the tag name be missing/not in the right format?");
                    }
                }
            }
            catch
            {
                Console.WriteLine("> There was an error while downloading.");
                return;
            }
        }

        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("> " + e.ProgressPercentage + "%...");
        }

        private static void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("> Complete. Installing...");

            try
            {
                if (Directory.Exists("Autoclave"))
                {
                    Console.WriteLine("> Deleting existing installation...");
                    Directory.Delete("Autoclave", true);
                }
                ZipFile.ExtractToDirectory("LatestBuild.zip", "Autoclave");
                File.WriteAllText("Record.launcher", buildversion.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("> Error installing. Info: ");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("> Complete.");
            Launch();
        }

        private static void Launch()
        {
            if (LaunchReady)
            {
                if (File.Exists("Autoclave/Autoclave.exe"))
                {
                    string current = Directory.GetCurrentDirectory();
                    System.Diagnostics.Process.Start(current + "/Autoclave/Autoclave.exe");
                }
                else
                    Console.WriteLine("Autoclave not installed. Please run \'update\'.");

                LaunchReady = false;
            }
        }

        public class ReleaseObject
        {
            public string name;
            public string published_at;
            public string tag_name;
            public AssetObject[] assets;
        }

        public class AssetObject
        {
            public string browser_download_url;
            public string name;
        }
    }
}
