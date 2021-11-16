using System;
namespace Monolog.Types
{
    public interface INode
    {
        string ToHTML();
        string ToMarkdown();
        string ToString();
    }
}
