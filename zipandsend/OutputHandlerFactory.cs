using zipandsendApp.Implementation;
using zipandsendApp.Interfaces;

namespace zipandsendApp
{
    public static class OutputHandlerFactory
    {
        public static IOutputHandler CreateOutput(string outputType, string outputOptions)
        {
            return outputType.ToLower() switch
            {
                "fileshare" => new FileShareOutput(outputOptions),
                "smtp" => new SmtpOutput(outputOptions),
                _ => new LocalFileOutput(),
            };
        }
    }
}
