using MdExport.ExportTypeSelector;

namespace MdExport.Exporter
{
    public interface IMultiExporter
    {
        string Export(IExportTypeSelector selector, string text);
    }
}