using System;
using System.Collections.Generic;

namespace GMOD_Server_Tools.classes
{

    [Serializable]
    internal class Server
    {
        private List<Addon> _addons;
        private string _name;
        private string _path;

        public Server(string path, List<Addon> addons, string name)
        {
            this._path = path ?? throw new ArgumentNullException(nameof(path));
            this._addons = addons ?? throw new ArgumentNullException(nameof(addons));
            this._name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Server(string path, string name)
        {
            this._path = path ?? throw new ArgumentNullException(nameof(path));
            this._addons = new List<Addon>();
            this._name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Server(string path)
        {
            this._path = path ?? throw new ArgumentNullException(nameof(path));
            this._addons = new List<Addon>();
            this._name = path.Substring(path.LastIndexOf('\\') + 1);
        }

        public Server(Server other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            Copy(other);
        }

        public void Copy(Server other)
        {
            this._name = other._name;
            this._path = other._path;
            this._addons = other.Addons;
        }

        public void AddAddon(Addon addon)
        {
            this.Addons.Add(addon);
        }

        public void AddAddons(List<Addon> addons)
        {
            foreach (Addon addon in addons)
            {
                this.Addons.Add(addon);
            }
        }

        public void RemoveAddon(Addon addon)
        {
            if (this.Addons.Contains(addon))
            {
                this.Addons.Remove(addon);
            }
        }

        public void RemoveAddons(List<Addon> addons)
        {
            if (_addons == null) return;
            for (int i = 0; i < addons.Count; i++)
            {
                if (this.Addons.Contains(addons[i]))
                {
                    this.Addons.Remove(addons[i]);
                }
            }
        }

        public void RemoveAllAddons()
        {
            Addons.Clear();
        }

        public List<Addon> Addons
        {
            get { return this.Addons; }
            set { this._addons = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Path
        {
            get { return this._path; }
            set { this._path = value; }
        }

        public override string ToString()
        {
            return this._path;
        }
    }
}
