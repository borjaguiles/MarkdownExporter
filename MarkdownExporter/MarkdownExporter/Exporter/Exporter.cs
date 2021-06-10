using System;

namespace MdExport.Exporter
{
    public abstract class Exporter
    {
        public Exporter()
        {
            
        }

        public abstract void AddOperations(Exporter operation);

        public abstract string ExportHtml(string text);
    }
}