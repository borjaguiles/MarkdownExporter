using MdExport.ExportTypeSelector;

namespace MdExport.Exporter
{
    public class MarkdownExporter : Exporter, IMultiExporter
    {
        public override void AddOperations(Exporter operation)
        {
            throw new System.NotImplementedException();
        }

        public override string ExportHtml(string text)
        {
            throw new System.NotImplementedException();
        }   

        public string Export(IExportTypeSelector selector, string text)
        {
            throw new System.NotImplementedException();
        }
    }
}