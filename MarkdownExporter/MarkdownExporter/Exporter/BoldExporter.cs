using System;

namespace MdExport.Exporter
{
    public class BoldExporter : Exporter
    {
        private const string BoldCharacter = "**";
        private const string BoldHtmlOpenCharacter = "<b>";
        private const int BoldHtmlOpenCharacterDifference = 1;
        private const string BoldHtmlCloseCharacter = "</b>";
        private const int BoldHtmlCloseCharacterDifference = 2;

        public override string ExportHtml(string text)
        {
            var index = 0;
            while (index < text.Length)
            {
                var nextBoldPosition = text.Substring(index).IndexOf(BoldCharacter);
                if (nextBoldPosition < 0)
                    break;
                var finalBoldPosition = text.Substring(index + nextBoldPosition+BoldCharacter.Length).IndexOf(BoldCharacter);
                if (finalBoldPosition < 0)
                    break;
                text = text.Remove(index + nextBoldPosition + finalBoldPosition + BoldCharacter.Length, BoldCharacter.Length)
                    .Insert(index + nextBoldPosition + finalBoldPosition + BoldCharacter.Length, BoldHtmlCloseCharacter)
                    .Remove(index + nextBoldPosition, BoldCharacter.Length)
                    .Insert(index + nextBoldPosition, BoldHtmlOpenCharacter);
                index += nextBoldPosition + BoldHtmlOpenCharacterDifference + finalBoldPosition +
                         BoldHtmlCloseCharacterDifference;
            }

            return text;
        }
    }
}