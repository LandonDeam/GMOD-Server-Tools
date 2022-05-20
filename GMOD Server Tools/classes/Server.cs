using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GMOD_Server_Tools
{

    [Serializable]
    internal class Server
    {
        private List<string> addons;
        private string name;
        private string path;

        public Server(string path, List<string> addons, string name)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
            this.addons = addons ?? throw new ArgumentNullException(nameof(addons));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Server(string path, string name)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
            this.addons = new List<string>();
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Server(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
            this.addons = new List<string>();
            this.name = path.Substring(path.LastIndexOf('\\') + 1);
        }

        public Server(Server other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            Copy(other);
        }

        public void Copy(Server other)
        {
            this.name = other.name;
            this.path = other.path;
            this.addons = other.addons;
        }

        public void addAddon(string addon)
        {
            this.addons.Add(addon);
        }

        public void addAddons(List<string> addons)
        {
            foreach (string addon in addons)
            {
                this.addons.Add(addon);
            }
        }

        public void removeAddon(string addon)
        {
            if (this.addons.Contains(addon))
            {
                this.addons.Remove(addon);
            }
        }

        public void removeAddons(List<string> addons)
        {
            for (int i = 0; i < addons.Count; i++)
            {
                if (addons.Contains(this.addons[i]))
                {
                    this.addons.Remove(addons[i]);
                }
            }
        }

        public void removeAllAddons()
        {
            int numAddon = this.addons.Count;
            for (int i = 0; i < numAddon; i++)
            {
                this.addons.RemoveAt(i);
            }
        }

        public List<string> Addons
        {
            get { return this.addons; }
            set { this.addons = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public override string ToString()
        {
            return this.path;
        }
    }
}
