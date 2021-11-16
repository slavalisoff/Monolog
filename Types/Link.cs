using System;
namespace Monolog.Types
{
    public class Link : INode
    {
        private const string Tag = "a";
        private readonly string Value;
        private readonly string Address;

        public Link(string value, string address)
        {
            Address = address;
            Value = value;
        }

        public string ToHTML()
        {
            return $"<a href=\"{Address}\">{Value}</a>";
        }

        public string ToMarkdown()
        {
            return $"[{Value}]({Address})";
        }

        public override string ToString()
        {
            return $"{Address} - {Value}";
        }
    }
}
