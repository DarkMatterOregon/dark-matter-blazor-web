using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ganss.XSS;
using Markdig;
using Microsoft.AspNetCore.Components;

namespace EugeneFoodScene.Data
{
    public class MarkdownComponent : ComponentBase
    {
        private string _content;

       // [Inject] public IHtmlSanitizer HtmlSanitizer { get; set; }

        [Parameter]
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                HtmlContent = ConvertStringToMarkupString(_content);
            }
        }

        public MarkupString HtmlContent { get; private set; }

        private MarkupString ConvertStringToMarkupString(string value)
        {
            if (!string.IsNullOrWhiteSpace(_content))
            {
                string readValue;
                var assembly = Assembly.GetEntryAssembly();
                var resourceStream = assembly.GetManifestResourceStream("DarkMatterWeb.wwwroot.Markdown." + value);
                if (resourceStream != null)
                {
                    using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
                    {
                        readValue = reader.ReadToEnd();
                    }
                }
                else
                {
                    readValue = $"markdown not found:{value}";
                }

                // Convert markdown string to HTML
                var html = Markdig.Markdown.ToHtml(readValue,
                    new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());

                var htmlSanitizer = new HtmlSanitizer();
                // Sanitize HTML before rendering
                var sanitizedHtml = htmlSanitizer.Sanitize(html);

                // Return sanitized HTML as a MarkupString that Blazor can render
                return new MarkupString(sanitizedHtml);
            }

            return new MarkupString();
        }
    }
}
