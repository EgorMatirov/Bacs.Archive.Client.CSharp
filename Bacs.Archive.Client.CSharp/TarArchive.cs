namespace Bacs.Archive.Client.CSharp
{
    public class TarArchive : IArchiveType
    {
        private TarArchive(string format)
        {
            Format = format;
        }

        public static TarArchive TarFormat => new TarArchive("");
        public static TarArchive GZipFormat => new TarArchive("gzip");
        public static TarArchive BZip2Format => new TarArchive("bzip2");
        public static TarArchive XzFormat => new TarArchive("xz");
        public static TarArchive LzmaFormat => new TarArchive("lzma");
        public static TarArchive LzopFormat => new TarArchive("lzop");

        public string Type => "tar";
        public string Format { get; }
    }
}