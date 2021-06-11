using Microsoft.Extensions.DependencyInjection;
using MdExport.Commands.ExportFileAsFile;
using MdExport.Contracts;
using MdExport.CrossCutting.Command;
using MdExport.Services.FileManager;

namespace MdExport
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IFileManager, FileManager>()
                .AddTransient<IRequestHandler<ExportFileAsFileRequestHandler>, ExportFileAsFileCommandHandler>()
                .AddTransient<IMdExport, MdExport>()
                .BuildServiceProvider();

            var exporter = serviceProvider.GetService<IMdExport>();
            exporter.RunCommand(args);
        }
    }
}
