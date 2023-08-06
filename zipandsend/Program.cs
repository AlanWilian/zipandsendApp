using System;
using System.IO;
using System.Security;
using zipandsendApp.Interfaces;
using zipandsendApp.Model;
using zipandsendApp.View;

namespace zipandsendApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    CommandLineView.DisplayMessage("Usage: zipandsendApp <SourceFolder> <OutputFile> [<ExcludedExtensions>] [<ExcludedDirectories>] [<ExcludedFiles>] [<OutputType>] [<OutputOptions>]");
                    return;
                }

                string outputType = args.Length > 5 ? args[5] : "localFile";
                string outputOptions = args.Length > 6 ? args[6] : null;

                IOutputHandler createOutputType = OutputHandlerFactory.CreateOutput(outputType, outputOptions);
                ZipSendModel zipModel = new ZipSendModel(createOutputType);         

                ZipController zipController = new ZipController(zipModel);             

                zipController.Run(args);

                CommandLineView.DisplayMessage("ZIP creation successful!");
            }
            catch (DirectoryNotFoundException e)
            {               
               CommandLineView.DisplayMessage($"Directory not found: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                CommandLineView.DisplayMessage($"Unauthorized access: {e.Message}");
            }
            catch (ArgumentException e)
            {
                CommandLineView.DisplayMessage($"Invalid argument: {e.Message}");
            }
            catch (PathTooLongException e)
            {
                CommandLineView.DisplayMessage($"Path too long: {e.Message}");
            }
            catch (NotSupportedException e)
            {
                CommandLineView.DisplayMessage($"Not supported: {e.Message}");
            }
            catch (IOException e)
            {
                CommandLineView.DisplayMessage($"I/O error: {e.Message}");
            }
            catch (SecurityException e)
            {
                CommandLineView.DisplayMessage($"Security error: {e.Message}");
            }

        }

    }
}