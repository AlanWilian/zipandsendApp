using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using zipandsendApp.Interfaces;

namespace zipandsendApp.Model
{
    public class ZipSendModel
    {
        private readonly IOutputHandler outputHandler;

        public ZipSendModel(IOutputHandler outputHandler)
        {
            this.outputHandler = outputHandler;
        }

        public void CompressFolder(string sourceFolder, string outputFile, string[] excludedExtensions, string[] excludedDirectories, string[] excludedFiles)
        {
            string[] filesToInclude = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);

            using (var archive = ZipFile.Open(outputFile, ZipArchiveMode.Create))
            {

                foreach (string fileToInclude in filesToInclude)
                {
                    string fileName = Path.GetFileName(fileToInclude);
                    string directoryName = Path.GetDirectoryName(fileToInclude);

                    if (ExcludedFile(fileName, excludedFiles) || ExcludedDirectory(directoryName, excludedDirectories) || ExcludedExtension(fileName, excludedExtensions))
                    {
                        continue;
                    }

                    string entryName = fileToInclude[(sourceFolder.Length + 1)..];

                    using (var fileStream = File.OpenRead(fileToInclude))
                    {
                        archive.CreateEntryFromFile(fileToInclude, entryName);
                    }
                }
            }

            outputHandler.Send(outputFile);
        }


        private static bool ExcludedFile(string fileName, string[] excludedFiles)
        {
            return excludedFiles != null && excludedFiles.Length > 0 && excludedFiles.Contains(fileName);
        }

        private static bool ExcludedDirectory(string directoryName, string[] excludedDirectories)
        {
            return excludedDirectories != null && excludedDirectories.Length > 0 && excludedDirectories.Contains(directoryName);
        }

        private static bool ExcludedExtension(string fileName, string[] excludedExtensions)
        {
            return excludedExtensions != null && excludedExtensions.Length > 0 && excludedExtensions.Contains(Path.GetExtension(fileName));
        }
    }
}
