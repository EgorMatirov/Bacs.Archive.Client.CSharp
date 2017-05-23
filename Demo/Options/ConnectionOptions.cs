using CommandLine;

namespace Demo.Options
{
    public class ConnectionOptions
    {
        [Option('h', "host", Required = true)]
        public string Host { get; set; }

        [Option('p', "port", Required = true)]
        public int Port { get; set; }

        [Option("cert", HelpText = "Client certificate", Required = true)]
        public string ClientCertificate { get; set; }

        [Option("key", HelpText = "Client private key", Required = true)]
        public string ClientKey { get; set; }

        [Option("ca", HelpText = "CA certificate", Required = true)]
        public string CaCertificate { get; set; }
    }
}