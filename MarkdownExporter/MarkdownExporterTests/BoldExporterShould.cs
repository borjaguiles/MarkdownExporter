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

        public BoldExporterShould()
        {
            _boldExporter = new BoldExporter();
        }

        [Theory]
        [InlineData("**This is bold**", "<b>This is bold</b>")]
        [InlineData("# Section/r/n**This is bold**/r/n**This is also bold**", "# Section/r/n<b>This is bold</b>/r/n<b>This is also bold</b>")]
        [InlineData("**This is bold****This is also bold**", "<b>This is bold</b><b>This is also bold</b>")]
        public void TransformMarkdownBoldIntoHtmlBold(string testText, string expectedText)
        {
            var resultText = _boldExporter.ExportHtml(testText);
            expectedText.Should().BeEquivalentTo(resultText);
        }
    }
}
