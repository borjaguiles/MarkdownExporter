using MdExport.Exporter;

namespace MdExport.ExportTypeSelector
{
    public class HtmlExportSelector : IExportTypeSelector
    {
        public string Select(Exporter.Exporter exporter, string text)
        {
            return exporter.ExportHtml(text);
        }
    }
}