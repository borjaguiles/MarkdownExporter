using System;
using System.Collections.Generic;
using MdExport.Contracts;
using MdExport.CrossCutting.Command;
using MdExport.Exporter;
using MdExport.ExportTypeSelector;

namespace MdExport.Commands.ExportFileAsFile
{
    public class ExportFileAsFileCommandHandler : IRequestHandler<ExportFileAsFileRequestHandler>
    {
        private readonly IFileManager _fileManager;
        private readonly MarkdownExporter _markdownExporter;
        private static Dictionary<Type, string> _filenameEndings;

        public ExportFileAsFileCommandHandler(IFileManager fileManager)
        {
            _fileManager = fileManager;
            _filenameEndings = new Dictionary<Type, string>();
            _filenameEndings.Add(typeof(HtmlExportSelector), "-html.html");
        }

        public void Handle(ExportFileAsFileRequestHandler request)
        {
            var file = _fileManager.GetFileAsText(request.FilePath);

            var transformedFile = _markdownExporter.Export(request.HtmlExportSelector, file);

            _fileManager.Create(GenerateFinalFilepath(request), transformedFile);
        }

        private static string GenerateFinalFilepath(ExportFileAsFileRequestHandler request)
        {
            var markdownFileExtension = ".md";
            var selectedExporterFilename = _filenameEndings[request.HtmlExportSelector.GetType()];
            return request.FilePath.Replace(markdownFileExtension, selectedExporterFilename);
        }
    }
}