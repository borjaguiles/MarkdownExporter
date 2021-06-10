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
            _selector = new HtmlExportSelector();
        }

        [Fact]
        public void TransformMarkdownsTextIntoHtmlText()
        {
            var text = "# This is a title/r/n/r/n**This is bold text**";
            var resultText = _markdownExporter.Export(_selector, text);
            var expectedTest = "<h1> this is a title </h1>/r/n/r/n<b>This is bold text</b>";
            expectedTest.Should().BeEquivalentTo(resultText);
        }
    }

}
