using System;

namespace MdExport.Exporter
{
    public abstract class Exporter
    {
        public Exporter()
        {
            
        }

        public virtual void AddOperations(Exporter operation)
        {
            throw new NotImplementedException();
        }

        public virtual string ExportHtml(string text)
        {
            throw new NotImplementedException();
        }
    }
}