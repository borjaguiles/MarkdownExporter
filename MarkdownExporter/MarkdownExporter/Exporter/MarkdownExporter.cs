using System;
using System.Collections.Generic;
using MdExport.ExportTypeSelector;

namespace MdExport.Exporter
{
    public class MarkdownExporter : Exporter, IMultiExporter
    {
        public List<Exporter> Operations { get; set; }

        public override void AddOperations(Exporter operation)
        {
            Operations.Add(operation);
        }

        public override string ExportHtml(string text)
        {
            foreach (var operation in Operations)
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