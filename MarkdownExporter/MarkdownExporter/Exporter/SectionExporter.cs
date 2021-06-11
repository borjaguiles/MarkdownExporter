using System;

namespace MdExport.Exporter
{
    public class SectionExporter : Exporter
    {
        private const int TitleCharacterOpenDifference = 3;
        private const int TitleCharacterCloseDifference = 4;
        private const char SectionCharacter = '#';
        private const int SectionCharacterLength = 1;

        public override string ExportHtml(string text)
        {
            int index = 0;
            while (index <= text.Length)
            {
                var startOfNextSection = text.Substring(index).IndexOf(SectionCharacter);
                if (startOfNextSection < 0)
                    break;
                var sectionlevel = FindSectionLevel(startOfNextSection + index, text);
                startOfNextSection += index;
                var sectionEnd = GetNextEndOfLineOrFile(startOfNextSection, text);
                text = text.Insert(sectionEnd, GetHtmlTitleEndingTag(sectionlevel))
                    .Remove(startOfNextSection,  sectionlevel)
                    .Insert(startOfNextSection, GetHtmlTitleOpeningTag(sectionlevel));
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