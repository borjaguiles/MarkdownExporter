using NSubstitute;
using MarkdownExporter.Commands.ExportFileAsFile;
using MarkdownExporter.Contracts;
using MarkdownExporter.CrossCutting.Command;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Xunit;

namespace MarkdownExporterTests
{
    public class MarkdownExporterShould
    {
        private readonly IFileManager _fileManager;
        private readonly IRequestHandler<ExportFileAsFileRequestHandler> _handler;

        public MarkdownExporterShould()
        {
            _fileManager = Substitute.For<IFileManager>();
            _handler = new ExportFileAsFileCommandHandler(_fileManager);
        }

        [Fact]
        public void ReturnAnHtmlFormatedFileGivenAMarkdownFile()
        {
            var expectedPath = "E:/Git/TestFiles/markdownSample.md";
            var expectedTextToSave = GetTestHtmlText();
            var testMarkdowntText = GetTestMarkdowntText();

            _fileManager.GetFileAsText(Arg.Is<string>(s => s == expectedPath)).Returns(testMarkdowntText);

            _handler.Handle(new ExportFileAsFileRequestHandler());

            _fileManager.Received(1).Create(Arg.Is<string>(s => s.Equals(expectedPath)), Arg.Is<string>(s => s == expectedTextToSave));
        }

        private static string GetTestMarkdowntText()
        {
            return "# Section 1\r\n\r\nSome **(bold) introduction** to Section 1.\r\n\r\n## Section 1.1\r\n\r\nA text describing Section 1.1\r\n\r\nSome conclusion to Section 1.\r\n\r\n# Section 2\r\n\r\nAn introduction to Section 2.\r\n\r\nSome conclusion to Section 2.;";
        }

        private static string GetTestHtmlText()
        {
            return "<h1> Section 1</h1>\r\n\r\nSome <b>(bold) introduction</b> to Section 1.\r\n\r\n<h2> Section 1.1</h2>\r\n\r\nA text describing Section 1.1\r\n\r\nSome conclusion to Section 1.\r\n\r\n<h1> Section 2</h1>\r\n\r\nAn introduction to Section 2.\r\n\r\nSome conclusion to Section 2.";
        }
    }
}
