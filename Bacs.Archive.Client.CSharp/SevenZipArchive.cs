namespace Bacs.Archive.Client.CSharp
{
    public class SevenZipArchive : IArchiveType
    {
        private SevenZipArchive(string format)
        {
            Format = format;
        }

        public static SevenZipArchive SevenZipFormat => new SevenZipArchive("7z");
        public static SevenZipArchive ZipFormat => new SevenZipArchive("zip");
        public static SevenZipArchive TarFormat => new SevenZipArchive("tar");

        public string Type => "7z";
        public string Format { get; }
    }
}
