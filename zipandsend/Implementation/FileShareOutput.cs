using System.IO;
using zipandsendApp.Interfaces;

namespace zipandsendApp.Implementation
{
    public class FileShareOutput : IOutputHandler
    {
        private readonly string fileSharePath;

        public FileShareOutput(string fileSharePath)
        {
            this.fileSharePath = fileSharePath;
        }

        public void Send(string filePath)
        {           
            string fileName = Path.GetFileName(filePath);
            string destinationPath = Path.Combine(fileSharePath, fileName);
            File.Copy(filePath, destinationPath, true);
        }
    }
}