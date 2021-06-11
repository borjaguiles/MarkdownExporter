using System;
using System.IO;
using MdExport.Contracts;

namespace MdExport.Services.FileManager
{
    public class FileManager : IFileManager
    {
        public void Create(string filePath, string textToSave)
        {
            File.WriteAllText(filePath, textToSave);
        }

        public string GetFileAsText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}