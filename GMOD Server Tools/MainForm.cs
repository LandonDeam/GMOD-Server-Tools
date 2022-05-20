using Microsoft.WindowsAPICodePack.Dialogs;
using SlavaGu.ConsoleAppLauncher;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Steamworks;
using SteamKit2;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMOD_Server_Tools
{
    public partial class frmGMODServerTools : Form
    {

        private CommonOpenFileDialog ofd = new CommonOpenFileDialog();
        private bool validFilePath = false;
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        private List<Server> servers;

        public frmGMODServerTools()
        {
            InitializeComponent();
            statusStrip.Visible = false;
            loadPathsFromFile();
        }

        private void loadPathsFromFile()
        {
            servers = (List<Server>) Methods.readFromBin($"{Directory.GetCurrentDirectory()}\\bin\\servers.bin");
            foreach(Server server in servers)
            {
                lstServers.Items.Add(server);
            }
        }

        private void writeServers()
        {
            Methods.WriteToBin(servers, $"{Directory.GetCurrentDirectory()}\\bin", "servers.bin");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Methods.UpdateAndInstall(lstServers, statusStrip, toolStripProgressBar, toolStripStatusLabel);
        }

        private void btnGetDirectory_Click(object sender, EventArgs e)
        {
            ofd.IsFolderPicker = true;
            ofd.Multiselect = true;
            errorProvider.Clear();
            ofd.ShowDialog();
            try
            {
                txtServerFolders.Text = "";
                foreach (string filePath in ofd.FileNames)
                {
                    if (!Directory.Exists(filePath))
                    {
                        txtServerFolders.Text = "";
                        errorProvider.SetError(btnGetDirectory, "ERROR: One or more directory added does not exist!");
                        validFilePath = false;
                        return;
                    }
                    txtServerFolders.Text += $"\"{filePath}\" ";
                }
                validFilePath = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            setAllBoxes(lstServers, true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            setAllBoxes(lstServers, false);
        }

        private void setAllBoxes(CheckedListBox list, bool value)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, value);
            }
        }

        private void setAllBoxesInverse(CheckedListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, !list.GetItemChecked(i));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < servers.Count; i++)
            {
                if (lstServers.GetItemChecked(i))
                {
                    servers.RemoveAt(i);
                    lstServers.Items.RemoveAt(i);
                    i--;
                }
            }
            writeServers();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (validFilePath)
            {
                txtServerFolders.Text = "";
                string filePath;
                for (int i = 0; i < Enumerable.Count(ofd.FileNames); i++)
                {
                    filePath = Enumerable.ElementAt(ofd.FileNames, i);
                    if (servers.ElementAt(i).Path.Equals(filePath)) continue;
                    servers.Add(new Server(filePath));
                    lstServers.Items.Add(filePath);
                }
            }
            writeServers();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            setAllBoxesInverse(lstServers);
        }

        private void btnGetAddon_Click(object sender, EventArgs e)
        {
            Addon addon = null;
            try
            {
                addon = Addon.getAddon(txtAddon.Text);
                if(addon == null)
                {
                    errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
                    return;
                }
                errorProvider.Clear();
                lstAddons.Items.Add(addon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
            }
        }
    }
}