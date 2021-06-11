
namespace MdExport.Contracts
{
    public interface IExportTypeSelector
    {
        string Select(Exporter.Exporter exporter, string text);
    }
}