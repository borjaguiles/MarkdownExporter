
namespace MdExport.ExportTypeSelector
{
    public interface IExportTypeSelector
    {
        string Select(Exporter.Exporter exporter, string text);
    }
}