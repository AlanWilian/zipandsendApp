using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using Xunit;
using zipandsendApp.Interfaces;
using zipandsendApp.Model;

namespace TestProjectZipsend
{
    [TestClass]
    public class ZipUtilityTests
    {
        [Fact]
        public void CompressFolder_zip()
        {
            // Arrange
            var outputHandlerMock = new Mock<IOutputHandler>();
            var zipSendModel = new ZipSendModel(outputHandlerMock.Object);

            var sourceFolder = "C:/Users/User/Desktop/source";
            var outputFile = "C:/Users/User/Desktop/output/output.zip";
            var excludedExtensions = new string[] { ".txt" };
            var excludedDirectories = new string[] { "excluida" };
            var excludedFiles = new string[] { "excluido.txt" };

            File.Delete(outputFile);

            zipSendModel.CompressFolder(sourceFolder, outputFile, excludedExtensions, excludedDirectories, excludedFiles);
            
            outputHandlerMock.Verify(handler => handler.Send(outputFile), Times.Once);
         
            Xunit.Assert.True(File.Exists(outputFile));
        }

        [Fact]
        public void CompressFolder_share()
        {           
            IOutputHandler outputHandler = null; 

            var sourceFolder = "C:/Users/User/Desktop/source";
            var outputFile = "C:/Users/User/Desktop/output/output.zip";
            var excludedExtensions = new string[] { ".txt" };
            var excludedDirectories = new string[] { "excluida" };
            var excludedFiles = new string[] { "excluido.txt" };

            var zipSendModel = new ZipSendModel(outputHandler);
           
            Xunit.Assert.Throws<ArgumentNullException>(() => zipSendModel.CompressFolder(sourceFolder, outputFile, excludedExtensions, excludedDirectories, excludedFiles));
        }
       
    }
}
