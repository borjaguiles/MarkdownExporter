using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MdExport.Exporter;
using MdExport.ExportTypeSelector;
using Xunit;

namespace MdExportTests
{
    public class HtmlMarkdownExporterShould
    {
        private MarkdownExporter _markdownExporter;
        private HtmlExportSelector _selector;

        public HtmlMarkdownExporterShould()
        {
            _markdownExporter = new MarkdownExporter();
            _markdownExporter.AddOperations(new SectionExporter());
            _markdownExporter.AddOperations(new BoldExporter());
            _selector = new HtmlExportSelector();
        }

        [Theory]
        [InlineData("# Section\r\n Hello I am **bold**\r\n", "<h1> Section</h1>\r\n Hello I am <b>bold</b>\r\n")]
        [InlineData("# Section\r\n Hello I am **bold**\r\n## Second Section\r\n**I am also bold**", "<h1> Section</h1>\r\n Hello I am <b>bold</b>\r\n<h2> Second Section</h2>\r\n<b>I am also bold</b>")]
        public void TransformMarkdownsTextIntoHtmlText(string markdownText, string expectedText)
        {
            var resultText = _markdownExporter.Export(_selector, markdownText);
            expectedText.Should().BeEquivalentTo(resultText);
        }
    }

}
