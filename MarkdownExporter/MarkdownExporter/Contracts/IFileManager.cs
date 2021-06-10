namespace MdExport.Contracts
{
    public interface IFileManager
    {
        public void Create(string filePath, string textToSave);
        string GetFileAsText(string filePath);
    }
}