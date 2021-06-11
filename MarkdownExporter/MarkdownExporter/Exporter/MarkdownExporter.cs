using System;
using System.Collections.Generic;
using MdExport.ExportTypeSelector;

namespace MdExport.Exporter
{
    public class MarkdownExporter : Exporter, IMultiExporter
    {
        private List<Exporter> _operations  = new List<Exporter>();

        public override void AddOperations(Exporter operation)
        {
            _operations.Add(operation);
        }

        public override string ExportHtml(string text)
        {
            foreach (var operation in _operations)
            {
                text = operation.ExportHtml(text);
            }

            return text;
        }   

        public string Export(IExportTypeSelector selector, string text)
        {
            return selector.Select(this, text);
        }
    }
}