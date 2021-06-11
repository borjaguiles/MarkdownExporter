using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MdExport.Exporter;
using Xunit;

namespace MdExportTests
{
    public class BoldExporterShould
    {
        private BoldExporter _boldExporter;

        [Fact]
        public void TransformMarkdownBoldIntoHtmlBold()
        {
            var testText = "**This is bold**";
            var resultText = _boldExporter.ExportHtml(testText);
            var expectedText = "<b>This is bold</b>";
            expectedText.Should().BeEquivalentTo(resultText);
        }
    }
}
