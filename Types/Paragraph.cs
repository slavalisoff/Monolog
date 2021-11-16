using System;
namespace Monolog.Types
{
    public class Paragraph : INode
    {
        private const string Tag = "p";
        private readonly string Value;

        public Paragraph(string value)
        {
            Value = value;
        }

        public string ToHTML()
        {
            return $"<p> {Value} </p>";
        }

        public string ToMarkdown()
        {
            return $"{Value}\n";
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
