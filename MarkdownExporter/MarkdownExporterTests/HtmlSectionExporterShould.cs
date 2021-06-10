using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MdExport.Exporter;
using Xunit;

namespace MdExportTests
{
    public class HtmlSectionExporterShould
    {
        private SectionExporter _sectionExporter;

        [Fact]
        public void ReturnHtmlTitleGivenMarkdownFirstLevelSection()
        {
            var markdownText = "# Section";
            var resultText = _sectionExporter.ExportHtml(markdownText);
            var expectedText = "<h1> Section</h1>";
            expectedText.Should().BeEquivalentTo(resultText);
        }
    }
}
