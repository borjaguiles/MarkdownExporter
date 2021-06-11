using MdExport.ExportTypeSelector;

namespace MdExport.Contracts
{
    public interface IMultiExporter
    {
        string Export(IExportTypeSelector selector, string text);
    }
}