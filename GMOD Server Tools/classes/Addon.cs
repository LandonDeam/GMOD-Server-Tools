using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Steamworks;
using SteamKit2;
using System.Threading.Tasks;
using System.Net;

namespace GMOD_Server_Tools
{
    [Serializable]
    internal class Addon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
        public string ID { get; set; }
        public Addon[] Dependencies { get; set; }

        public Addon(string name, string description, string[] authors, Addon[] dependencies, string id)
        {
            Name = name;
            Description = description;
            Authors = authors;
            Dependencies = dependencies;
            ID = id;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static Addon getAddon(string input)
        {
            if (input == null)
                return null;
            string ID = Regex.Match(input, "[0-9]+").Value;
            WebClient wc = new WebClient();
            string downloadString = wc.DownloadString($"https://steamcommunity.com/sharedfiles/filedetails/?id={ID}");
            if (!downloadString.Contains("<div class=\"apphub_AppName ellipsis\">Garry's Mod</div>"))
                throw new Exception("Not a GMOD addon");
            return new Addon(Regex.Match(downloadString, "(?<=<div class=\"workshopItemTitle\">)(.*)(?=</div>)").Value,
                             Regex.Match(downloadString, "(?<=<div class=\"workshopItemDescription\" id=\"highlightContent\">)(.*)(?=</div>)").Value,
                             Regex.Matches(downloadString, "(?<=<div class=\"friendBlockContent\">\n)(.*)(?=<br>)")
                                .Cast<Match>().Select(m => m.Value).ToArray(),
                             Regex.Matches(downloadString, "(?<=<a href=\"https://steamcommunity\\.com/workshop/filedetails/\\?id=)([0-9]*)(?=\")")
                                .Cast<Match>().Select(m => getAddon(m.Value)).ToArray(),
                             ID
                             );
        }
    }
}
