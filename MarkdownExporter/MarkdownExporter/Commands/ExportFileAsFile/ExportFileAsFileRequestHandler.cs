using MdExport.ExportTypeSelector;

namespace MdExport.Commands.ExportFileAsFile
{
    public class ExportFileAsFileRequestHandler
    {
        public string FilePath { get; private set; }
        public HtmlExportSelector HtmlExportSelector { get; private set; }


        public ExportFileAsFileRequestHandler(string filePath, HtmlExportSelector htmlExportSelector)
        {
            FilePath = filePath;
            HtmlExportSelector = htmlExportSelector;
        }
    }
}