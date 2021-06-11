using System;

namespace MdExport.Exporter
{
    public class BoldExporter : Exporter
    {
        private const string BoldCharacter = "**";
        private const string BoldHtmlOpenCharacter = "<b>";
        private const string BoldHtmlCloseCharacter = "</b>";

        public override string ExportHtml(string text)
        {
            var nextBoldPosition = text.IndexOf(BoldCharacter);
            var finalBoldPosition = text.Substring(nextBoldPosition+BoldCharacter.Length).IndexOf(BoldCharacter);
            return text.Remove(finalBoldPosition+BoldCharacter.Length, BoldCharacter.Length)
                .Insert(finalBoldPosition+BoldCharacter.Length, BoldHtmlCloseCharacter)
                .Remove(nextBoldPosition, BoldCharacter.Length)
                .Insert(nextBoldPosition, BoldHtmlOpenCharacter);

        }
    }
}