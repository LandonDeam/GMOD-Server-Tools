using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GMOD_Server_Tools.classes;
using GMOD_Server_Tools.tools;

namespace GMOD_Server_Tools
{
    public partial class FrmGmodServerTools : Form
    {

        private CommonOpenFileDialog _ofd = new CommonOpenFileDialog();
        private bool _validFilePath;
        private List<Server> _servers;
        internal List<Addon> Addons;

        public FrmGmodServerTools()
        {
            InitializeComponent();
            statusStrip.Visible = false;
            LoadPathsFromFile();
        }

        private void LoadPathsFromFile()
        {
            _servers = (List<Server>)Methods.ReadFromBin($"{Directory.GetCurrentDirectory()}\\bin\\servers.bin");
            if (_servers != null)
                foreach (Server server in _servers)
                    lstServers.Items.Add(server);
            Addons = (List<Addon>)Methods.ReadFromBin($"{Directory.GetCurrentDirectory()}\\bin\\addons.bin");
            if (Addons != null)
                foreach (Addon addon in Addons)
                    lstAddons.Items.Add(addon);
        }

        private void WriteServers()
        {
            Methods.WriteToBin(_servers, $"{Directory.GetCurrentDirectory()}\\bin", "servers.bin");
        }

        private void WriteAddons()
        {
            Methods.WriteToBin(Addons, $"{Directory.GetCurrentDirectory()}\\bin", "addons.bin");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Methods.UpdateAndInstall(lstServers, statusStrip, toolStripProgressBar, toolStripStatusLabel);
        }

        private void btnGetDirectory_Click(object sender, EventArgs e)
        {
            _ofd.IsFolderPicker = true;
            _ofd.Multiselect = true;
            errorProvider.Clear();
            _ofd.ShowDialog();
            try
            {
                txtServerFolders.Text = "";
                foreach (string filePath in _ofd.FileNames)
                {
                    if (!Directory.Exists(filePath))
                    {
                        txtServerFolders.Text = "";
                        errorProvider.SetError(btnGetDirectory, "ERROR: One or more directory added does not exist!");
                        _validFilePath = false;
                        return;
                    }
                    txtServerFolders.Text += $@"""{filePath}"" ";
                }
                _validFilePath = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SetAllBoxes(lstServers, true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            SetAllBoxes(lstServers, false);
        }

        private void SetAllBoxes(CheckedListBox list, bool value)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, value);
            }
        }

        private void SetAllBoxesInverse(CheckedListBox list)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                list.SetItemChecked(i, !list.GetItemChecked(i));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _servers.Count; i++)
            {
                if (lstServers.GetItemChecked(i))
                {
                    _servers.RemoveAt(i);
                    lstServers.Items.RemoveAt(i);
                    i--;
                }
            }
            WriteServers();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (_servers == null) _servers = new List<Server>();
            if (_validFilePath)
            {
                txtServerFolders.Text = "";
                string filePath;
                for (int i = 0; i < Enumerable.Count(_ofd.FileNames); i++)
                {
                    filePath = Enumerable.ElementAt(_ofd.FileNames, i);
                    if (_servers.Select(m => m.Path).Contains(filePath)) continue;
                    _servers.Add(new Server(filePath));
                    lstServers.Items.Add(filePath);
                }
            }
            WriteServers();
        }

        private void btnInverse_Click(object sender, EventArgs e)
        {
            SetAllBoxesInverse(lstServers);
        }

        private void btnGetAddon_Click(object sender, EventArgs e)
        {
            Addon addon;
            try
            {
                addon = Addon.GetAddon(txtAddon.Text);
                if (addon == null)
                {
                    errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
                    return;
                }
                errorProvider.Clear();
                AddAddon(addon);
                WriteAddons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                errorProvider.SetError(txtAddon, "ERROR: Addon not found!");
            }
        }

        private void AddAddon(Addon addon)
        {
            if (Addons == null) Addons = new List<Addon>();
            if (Addons.Select(m => m.Id).Contains(addon.Id)) return;
            lstAddons.Items.Add(addon);
            Addons.Add(addon);
            foreach (Addon dependency in addon.Dependencies)
            {
                AddAddon(dependency);
            }
        }

        private void AddonStateChanged(object sender, ItemCheckEventArgs e)
        {
            errorProvider.Clear();
            Addon[] dependencies = ((Addon)lstAddons.Items[e.Index]).Dependencies;
            if (e.NewValue == CheckState.Checked && dependencies != null)
            {
                for (int i = 0; i < lstAddons.Items.Count; i++)
                {
                    if (dependencies.Select(m => m.Id).Contains(((Addon)lstAddons.Items[i]).Id))
                    {
                        lstAddons.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < lstAddons.Items.Count; i++)
                {
                    if (((Addon)lstAddons.Items[i]).Dependencies.Select(m => m.Id).Contains(((Addon)lstAddons.Items[e.Index]).Id))
                    {
                        errorProvider.SetError(lstAddons, $"\"{lstAddons.Items[i]}\" requires \"{lstAddons.Items[e.Index]}\" to work");
                        e.NewValue = CheckState.Checked;
                    }
                }
            }
        }
    }
}