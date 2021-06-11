using System;
using System.Collections.Generic;
using MdExport.Commands.ExportFileAsFile;
using MdExport.Contracts;
using MdExport.CrossCutting.Command;
using MdExport.ExportTypeSelector;

namespace MdExport
{
    public class MdExport : IMdExport
    {
        private Dictionary<string, IExportTypeSelector> selectionary;
        private IRequestHandler<ExportFileAsFileRequestHandler> _handler;

        public MdExport(IRequestHandler<ExportFileAsFileRequestHandler> handler)
        {
            _handler = handler;
            selectionary = new Dictionary<string, IExportTypeSelector>();
            selectionary.Add("-html", new HtmlExportSelector());
        }

        private const int ExportKind = 0;
        private const int InputFilePath = 2;

        public void RunCommand(string[] arguments)
        {
            IExportTypeSelector selector;
            selector = selectionary[arguments[ExportKind]];

            var filePath = arguments[InputFilePath];
            _handler.Handle(new ExportFileAsFileRequestHandler(filePath, selector));
        }
    }
}