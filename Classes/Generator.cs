using System;
using Monolog.Types;
namespace Monolog.Classes
{
    public class Generator
    {
        public string GenerateHTML(INode[] nodes, INode[] links)
        {
            string html = "";
            foreach (INode n in nodes) html += n.ToHTML();
            var buf = html.Split(' ');
            html = "";
            int i = 0;
            foreach(string w in buf) if(w == "(link)")
                {
                    html += links[i].ToHTML();
                    i++;
                }
                else
                {
                    html += $"{w} ";
                }
            html = html.Replace("  ", " ");
            html = html.Replace(" ,", ",");
            html = html.Replace(" </a", "</a");
            html = html.Replace("\"> ", "\">");
            return html;
        }
        public string GenerateMarkdown(INode[] nodes, INode[] links)
        {
            string md = "";
            foreach (INode n in nodes) md += n.ToMarkdown();
            var buf = md.Split(' ');
            md = "";
            int i = 0;
            foreach (string w in buf) if (w == "(link)")
                {
                    md += links[i].ToMarkdown();
                    i++;
                }
                else
                {
                    md += $"{w} ";
                }
            md = md.Replace("  ", " ");
            md = md.Replace(" ,", ",");
            return md;
        }
    }
}
