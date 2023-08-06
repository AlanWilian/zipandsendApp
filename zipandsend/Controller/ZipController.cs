using System;
using zipandsendApp.Model;

namespace zipandsendApp.View
{

    public class ZipController
    {
        private readonly ZipSendModel zipModel;

        public ZipController(ZipSendModel zipModel)
        {
            this.zipModel = zipModel;
        }

        public void Run(string[] args)
        {
            string sourceFolder = args[0];
            string outputFile = args[1];
            string[] excludedExtensions = args.Length > 2 ? args[2].Split(',') : Array.Empty<string>();
            string[] excludedDirectories = args.Length > 3 ? args[3].Split(',') : Array.Empty<string>();
            string[] excludedFiles = args.Length > 4 ? args[4].Split(',') : Array.Empty<string>();

            zipModel.CompressFolder(sourceFolder, outputFile, excludedExtensions, excludedDirectories, excludedFiles);

        }
    }

}