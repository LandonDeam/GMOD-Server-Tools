using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace GMOD_Server_Tools.classes
{
    [Serializable]
    internal class Addon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
        public string Id { get; set; }
        public Addon[] Dependencies { get; set; }

        public Addon(string name, string description, string[] authors, Addon[] dependencies, string id)
        {
            Name = name;
            Description = description;
            Authors = authors;
            Dependencies = dependencies;
            Id = id;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public static Addon GetAddon(string input)
        {
            if (input == null)
                return null;
            string id = Regex.Match(input, "[0-9]+").Value;
            WebClient wc = new WebClient();
            string downloadString = wc.DownloadString($"https://steamcommunity.com/sharedfiles/filedetails/?id={id}");
            if (!downloadString.Contains("<div class=\"apphub_AppName ellipsis\">Garry's Mod</div>"))
                throw new Exception("Not a GMOD addon");
            return new Addon(Regex.Match(downloadString, "(?<=<div class=\"workshopItemTitle\">)(.*)(?=</div>)").Value,
                             Regex.Match(downloadString, "(?<=<div class=\"workshopItemDescription\" id=\"highlightContent\">)(.*)(?=</div>)").Value,
                             Regex.Matches(downloadString, "(?<=<div class=\"friendBlockContent\">\n)(.*)(?=<br>)")
                                .Cast<Match>().Select(m => m.Value).ToArray(),
                             Regex.Matches(downloadString, "(?<=<a href=\"https://steamcommunity\\.com/workshop/filedetails/\\?id=)([0-9]*)(?=\")")
                                .Cast<Match>().Select(m => GetAddon(m.Value)).ToArray(),
                             id
                             );
        }
    }
}
