using SlavaGu.ConsoleAppLauncher;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GMOD_Server_Tools
{
    internal class Threads
    {
        public static Task RunUpdate(Server server, IProgress<bool> bar, IProgress<int> progress, IProgress<string> stat, string steamcmd)
        {
            Regex regex = new Regex("(progress: )(?<progress>[0-9]{1,2}.[0-9]{2})", RegexOptions.Compiled);
            string commands = 
                $"+@ShutdownOnFailedCommand 0 +@NoPromptForPassword 1 +force_install_dir {server} +login anonymous +app_update 4020 validate +quit";
            ConsoleApp app = new ConsoleApp(steamcmd, commands);
            
            app.ConsoleOutput += (o, args) =>
            {
                bar.Report(true);
                Match match = regex.Match(args.Line);
                if (match.Success)
                {
                    progress.Report((int)double.Parse(match.Groups["progress"].Value));
                    if (args.Line.Contains("verifying"))
                        stat.Report($"Verifying {server.Name}");
                    else
                        stat.Report($"Installing {server.Name}");
                }
                else if (args.Line.Equals("Success! App '4020' fully installed."))
                {
                    stat.Report($"Finished {server.Name}");
                }
            };
            app.Exited += (o, args) =>
            {
                app.Dispose();
                bar.Report(false);
            };
            bar.Report(true);

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return Task.CompletedTask;
        }

        public static Task DownloadAddon(Addon addon, IProgress<bool> bar, IProgress<int> progress, IProgress<string> stat, string steamcmd)
        {


            return Task.CompletedTask;
        }
    }
}
