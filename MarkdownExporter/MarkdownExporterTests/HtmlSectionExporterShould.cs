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

        public HtmlSectionExporterShould()
        {
            _sectionExporter = new SectionExporter();
        }

        [Theory]
        [InlineData("# Section", "<h1> Section</h1>")]
        [InlineData("# Section/r/n/r/n# SecondSection", "<h1> Section</h1>/r/n/r/n<h1> SecondSection</h1>")]
        [InlineData("# Section/r/n/r/nThis is a normal paragraph/r/n/r/n# SecondSection", "<h1> Section</h1>/r/n/r/nThis is a normal paragraph/r/n/r/n<h1> SecondSection</h1>")]
        public void ReturnHtmlTitleGivenMarkdownFirstLevelSection(string markdownText, string expectedText)
        {
            var resultText = _sectionExporter.ExportHtml(markdownText);
            expectedText.Should().BeEquivalentTo(resultText);
        }

        [Theory]
        [InlineData("## Section", "<h2> Section</h2>")]
        public void ReturnHtmlSecondTitleGivenMarkdownSecondLevelSection(string markdownText, string expectedText)
        {
            var resultText = _sectionExporter.ExportHtml(markdownText);
            expectedText.Should().BeEquivalentTo(resultText);
        }
    }
}
