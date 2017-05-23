using Grpc.Core;

namespace Bacs.Archive.Client.CSharp
{
    public static class ArchiveClientFactory
    {
        public static IArchiveClient CreateFromFiles(string host, int port, string clientCertificatePath, string clientKeyPath, string caCertificatePath)
        {
            var clientCertificate = System.IO.File.ReadAllText(clientCertificatePath);
            var clientKey = System.IO.File.ReadAllText(clientKeyPath);
            var caCertificate = System.IO.File.ReadAllText(caCertificatePath);
            return Create(host, port, clientCertificate, clientKey, caCertificate);
        }

        public static IArchiveClient Create(string host, int port, string clientCertificate, string clientKey, string caCertificate)
        {
            var ssl = new SslCredentials(caCertificate, new KeyCertificatePair(clientCertificate, clientKey));
            var channel = new Channel($"{host}:{port}", ssl);
            var innerClient = new Archive.ArchiveClient(channel);
            return new ArchiveClient(innerClient);
        }
    }
}