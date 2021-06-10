using System;
using MarkdownExporter.Contracts;
using MarkdownExporter.CrossCutting.Command;

namespace MarkdownExporter.Commands.ExportFileAsFile
{
    public class ExportFileAsFileCommandHandler : IRequestHandler<ExportFileAsFileRequestHandler>
    {
        public ExportFileAsFileCommandHandler(IFileManager fileManager)
        {
            throw new NotImplementedException();
        }

        public void Handle(ExportFileAsFileRequestHandler request)
        {
            throw new NotImplementedException();
        }
    }
}