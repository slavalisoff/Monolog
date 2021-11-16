using System;
using System.Collections.Generic;
using System.IO;
using Monolog.Types;
using System.Linq;

namespace Monolog.Classes
{
    public class Parser
    {
        private List<INode> Nodes;
        private List<Link> Links;
        private StreamReader Source;

        public Parser(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException($"File {path} not found");
            Source = File.OpenText(path);
            Nodes = new List<INode>();
            Links = new List<Link>();
        }

        public INode[][] Parse()
        {
            string s;
            while((s = Source.ReadLine()) != null)
            {
                string[] w = s.Split(' ');
                bool parsingLink = false;
                string linkAddress = "";
                string linkValue = "";
                string paragraph = "";
                for (int i = 0; i < w.Length; i++)
                {
                    if (!parsingLink) 
                    {
                        if (w[i] == "(link)")
                        {
                            parsingLink = true;
                            i++;
                            linkAddress = w[i];
                        }
                        else paragraph += $" {w[i]} ";
                    }
                    else if (parsingLink)
                    {
                        if (w[i] == "(link)")
                        {
                            parsingLink = false;
                            Links.Add(new Link(linkValue, linkAddress));
                            linkValue = "";
                            paragraph += " (link) ";
                        }
                        else linkValue += $" {w[i]} ";
                    }
                }
                Nodes.Add(new Paragraph(paragraph));
            }
            return new INode[][]{ Nodes.ToArray(), Links.ToArray() };
        }

        ~Parser()
        {
            Source.Close();
        }
    }
}
