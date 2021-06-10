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
        public void TransformMarkdownsSectionIntoHtmlTitle()
        {
            var text = "# This is a title";
            var resultText = _markdownExporter.Export(_selector, text);
            var expectedTest = "<h1> this is a title </h1>";
            expectedTest.Should().BeEquivalentTo(resultText);
        }
    }

}
