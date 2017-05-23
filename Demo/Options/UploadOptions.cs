using CommandLine;

namespace Demo.Options
{
    [Verb("upload")]
    public class UploadOptions : ConnectionOptions
    {
        [Option("source", Required = true, HelpText = "Archive to be uploaded.")]
        public string Source { get; set; }
    }
}