using System;
using System.Collections.Generic;
using System.Linq;
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
                // Convert markdown string to HTML
                var html = Markdig.Markdown.ToHtml(value,
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
