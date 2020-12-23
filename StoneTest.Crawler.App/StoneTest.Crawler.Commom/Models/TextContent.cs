using System.Text;

namespace StoneTest.Crawler.Commom.Models
{
    public class TextContent
    {
        public TextContent()
        {
            Content = new StringBuilder();
            ContentInfo = new ContentInfo();
        }

        public StringBuilder Content { get; set; }
        public ContentInfo ContentInfo { get; set ; }
    }
}
