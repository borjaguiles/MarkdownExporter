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
            while (index < text.Length)
            {
                var startOfNextSection = text.Substring(index).IndexOf(SectionCharacter);
                if (startOfNextSection < 0)
                    break;
                startOfNextSection += index;
                var sectionLevel = FindSectionLevel(startOfNextSection, text);
                var sectionEnd = GetNextEndOfLineOrFile(startOfNextSection, text);
                text = text.Insert(sectionEnd, GetHtmlTitleEndingTag(sectionLevel))
                    .Remove(startOfNextSection,  sectionLevel)
                    .Insert(startOfNextSection, GetHtmlTitleOpeningTag(sectionLevel));
                index = sectionEnd + TitleCharacterOpenDifference + TitleCharacterCloseDifference;
            }

            return text;
        }

        private static string GetHtmlTitleEndingTag(int sectionlevel)
        {
            return "</h"+sectionlevel+">";
        }

        private static string GetHtmlTitleOpeningTag(int sectionlevel)
        {
            return "<h"+sectionlevel+">";
        }

        private int FindSectionLevel(int sectionStart, string text)
        {
            if (text[sectionStart] == SectionCharacter)
            {
                return FindSectionLevel(sectionStart + 1, text) + 1;
            }

            return 0;
        }

        private int GetNextEndOfLineOrFile(int startOfNextSection, string text)
        {
            var nextSegment = text.Substring(startOfNextSection);
            
            var endOfSection = nextSegment.IndexOf(Environment.NewLine);
            if (endOfSection == -1)
            {
                return text.Length;
            }

            return endOfSection + startOfNextSection;
        }
    }
}