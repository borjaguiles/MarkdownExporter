using System;

namespace MdExport.Exporter
{
    public class SectionExporter : Exporter
    {
        private const char SectionCharacter = '#';

        public override string ExportHtml(string text)
        {
            int index = 0;
            while (true)
            {
                var startOfNextSection = text.Substring(index).IndexOf(SectionCharacter);
                if (startOfNextSection == -1)
                    break;
                var sectionEnd = GetNextEndOfLineOrFile(startOfNextSection, text);
                text = text.Remove(startOfNextSection, 1);
                text = text.Insert(sectionEnd, "</h1>");
                text = text.Insert(startOfNextSection, "<h1>");
                index = sectionEnd;
            }

            return text;
        }

        private int GetNextEndOfLineOrFile(int startOfNextSection, string text)
        {
            var forwardedText = text.Substring(startOfNextSection);
            
                var endOfSection = forwardedText.IndexOf(Environment.NewLine);
                if (endOfSection == -1)
                {
                    return text.Length - 1;
                }

                return endOfSection;
        }
    }
}