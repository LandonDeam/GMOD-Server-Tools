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
        private List<Addon> addons;

        public frmGMODServerTools()
        {
            InitializeComponent();
            statusStrip.Visible = false;
            loadPathsFromFile();
        }

        private void loadPathsFromFile()
        {
            servers = (List<Server>)Methods.readFromBin($"{Directory.GetCurrentDirectory()}\\bin\\servers.bin");
            if (servers != null)
                foreach (Server server in servers)
                    lstServers.Items.Add(server);
            addons = (List<Addon>)Methods.readFromBin($"{Directory.GetCurrentDirectory()}\\bin\\addons.bin");
            if (addons != null)
                foreach (Addon addon in addons)
                    lstAddons.Items.Add(addon);
        }

        private void writeServers()
        {
            Methods.WriteToBin(servers, $"{Directory.GetCurrentDirectory()}\\bin", "servers.bin");
        }

        private void writeAddons()
        {
            Methods.WriteToBin(addons, $"{Directory.GetCurrentDirectory()}\\bin", "addons.bin");
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
            if (servers == null) servers = new List<Server>();
            if (validFilePath)
            {
                txtServerFolders.Text = "";
                string filePath;
                for (int i = 0; i < Enumerable.Count(ofd.FileNames); i++)
                {
                    filePath = Enumerable.ElementAt(ofd.FileNames, i);
                    if (servers.Select(m => m.Path).Contains(filePath)) continue;
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
                if (addon == null)
                {
                    errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
                    return;
                }
                errorProvider.Clear();
                addAddon(addon);
                writeAddons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
            }
        }

        private void addAddon(Addon addon)
        {
            if (addons == null) addons = new List<Addon>();
            if (addons.Select(m => m.ID).Contains(addon.ID)) return;
            lstAddons.Items.Add(addon);
            addons.Add(addon);
            foreach (Addon dependency in addon.Dependencies)
            {
                addAddon(dependency);
            }
        }

        private void addonStateChanged(object sender, ItemCheckEventArgs e)
        {
            errorProvider.Clear();
            Addon[] dependencies = ((Addon)lstAddons.Items[e.Index]).Dependencies;
            if (e.NewValue == CheckState.Checked && dependencies != null)
            {
                for (int i = 0; i < lstAddons.Items.Count; i++)
                {
                    if (dependencies.Select(m => m.ID).Contains(((Addon)lstAddons.Items[i]).ID))
                    {
                        lstAddons.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < lstAddons.Items.Count; i++)
                {
                    if (((Addon)lstAddons.Items[i]).Dependencies.Select(m => m.ID).Contains(((Addon)lstAddons.Items[e.Index]).ID))
                    {
                        errorProvider.SetError(lstAddons, $"\"{lstAddons.Items[i]}\" requires \"{lstAddons.Items[e.Index]}\" to work");
                        e.NewValue = CheckState.Checked;
                    }
                }
            }
        }
    }
}