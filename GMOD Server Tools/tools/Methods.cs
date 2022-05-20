using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMOD_Server_Tools
{
    internal class Methods
    {
        public static async void UpdateAndInstall(
            CheckedListBox listBox, StatusStrip statusStrip, ToolStripProgressBar progressBar, ToolStripStatusLabel status)
        {
            IProgress<bool> bar = new Progress<bool>(b => statusStrip.Visible = b);
            IProgress<int> progress = new Progress<int>(i => progressBar.Value = i);
            IProgress<string> stat = new Progress<string>(s => status.Text = s);
            stat.Report("Getting ready...");
            progress.Report(0);
            string steamcmd = GetSteamCmdPath();
            for(int i = 0; i < listBox.CheckedItems.Count; i++)
            {
                await Task.Factory.StartNew(() => 
                Threads.RunUpdate((Server)listBox.CheckedItems[i], bar, progress, stat, steamcmd), 
                TaskCreationOptions.LongRunning);
            }
        }

        public static string GetSteamCmdPath()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\bin\\consolepath.bin"))
                return (string)ReadFromBin(Directory.GetCurrentDirectory() + "\\bin\\consolepath.bin");
            if (File.Exists("C:\\steamcmd\\steamcmd.exe"))
            {
                WriteToBin("C:\\steamcmd\\steamcmd.exe", Directory.GetCurrentDirectory() + "\\bin\\", "consolepath.bin");
                return "C:\\steamcmd\\steamcmd.exe";
            }

            CommonOpenFileDialog ofd = new CommonOpenFileDialog();
            ofd.IsFolderPicker = false;
            ofd.Title = "Select steamcmd.exe";
            ofd.EnsureFileExists = true;
            ofd.EnsurePathExists = true;
            ofd.DefaultDirectory = "C:\\";
            ofd.Filters.Add(new CommonFileDialogFilter("SteamCMD", ".exe"));
            ofd.Multiselect = false;
            do { } while (!(ofd.ShowDialog() == CommonFileDialogResult.Ok && ofd.FileName.Contains("steamcmd.exe")));
            WriteToBin(ofd.FileName, Directory.GetCurrentDirectory() + "\\bin\\", "consolepath.bin");
            return ofd.FileName;
        }
        
        public static byte[] ToByteArray<T>(T data)
        {
            BinaryFormatter binf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                binf.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        public static bool WriteToBin<T>(T data, string directory, string fileName)
        {
            try
            {
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                File.WriteAllBytes($"{directory}\\{fileName}", ToByteArray(data));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public static FileStream GetFs(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("The file does not exist", path);
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        public static object ReadFromBin(string path)
        {
            FileStream fs = null;
            try
            {
                fs = GetFs(path);
                BinaryFormatter bf = new BinaryFormatter();
                using (fs)
                {
                    return bf.Deserialize(fs);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No previous saves of servers was found. Continuing anyways.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                try
                {
                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception while closing file stream: " + ex.Message);
                }
            }
            return null;
        }
    }
}
