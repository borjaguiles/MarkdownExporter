using MdExport.Exporter;

namespace MdExport.ExportTypeSelector
{
    public interface IExportTypeSelector
    {
        string Select(IMultiExporter exporter, string text);
    }
}