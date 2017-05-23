using CommandLine;

namespace Demo.Options
{
    [Verb("download")]
    public class DownloadOptions : ConnectionOptions
    {
        [Option("id", Required = true, HelpText = "Id of problem to be downloaded")]
        public string Id { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file")]
        public string Target { get; set; }
    }
}