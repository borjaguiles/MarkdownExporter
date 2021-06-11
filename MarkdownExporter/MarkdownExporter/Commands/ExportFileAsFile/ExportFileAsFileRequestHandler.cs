using MdExport.Contracts;
using MdExport.ExportTypeSelector;

namespace MdExport.Commands.ExportFileAsFile
{
    public class ExportFileAsFileRequestHandler
    {
        public string FilePath { get; private set; }
        public IExportTypeSelector HtmlExportSelector { get; private set; }


        public ExportFileAsFileRequestHandler(string filePath, IExportTypeSelector htmlExportSelector)
        {
            FilePath = filePath;
            HtmlExportSelector = htmlExportSelector;
        }
    }
}