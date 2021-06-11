using System;

namespace MdExport.Exporter
{
    public class SectionExporter : Exporter
    {
        private const int TitleCharacterOpenDifference = 3;
        private const int TitleCharacterCloseDifference = 4;
        private const char SectionCharacter = '#';

        public override string ExportHtml(string text)
        {
            int index = 0;
            while (index <= text.Length)
            {
                var startOfNextSection = text.Substring(index).IndexOf(SectionCharacter);
                if (startOfNextSection < 0)
                    break;
                startOfNextSection += index;
                var sectionEnd = GetNextEndOfLineOrFile(startOfNextSection, text);
                text = text.Insert(sectionEnd, "</h1>");
                text = text.Remove(startOfNextSection, 1);
                text = text.Insert(startOfNextSection, "<h1>");
                index = sectionEnd + TitleCharacterOpenDifference + TitleCharacterCloseDifference;
            }

            return text;
        }

        private int GetNextEndOfLineOrFile(int startOfNextSection, string text)
        {
            var forwardedText = text.Substring(startOfNextSection);
            
                var endOfSection = forwardedText.IndexOf("/r/n");
                if (endOfSection == -1)
                {
                    return text.Length;
                }

                return endOfSection;
        }
    }
}