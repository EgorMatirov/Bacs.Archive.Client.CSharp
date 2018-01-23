using System.Collections.Generic;
using System.Threading.Tasks;
using Bacs.Archive.Problem;

namespace Bacs.Archive.Client.CSharp
{
    public interface IArchiveClient
    {
        StatusResult Rename(string from, string to);

        Task<byte[]> DownloadAsync(IArchiveType archiveType, params string[] ids);
        byte[] Download(IArchiveType archiveType, params string[] ids);
        Task<Dictionary<string, StatusResult>> UploadAsync(IArchiveType archiveType, IEnumerable<byte> bytes);
        Dictionary<string, StatusResult> Upload(IArchiveType archiveType, IEnumerable<byte> bytes);

        IEnumerable<string> Existing(params string[] ids);
        IEnumerable<string> ExistingAll();

        Dictionary<string, StatusResult> Status(params string[] ids);
        Dictionary<string, StatusResult> StatusAll();
        (string revision, Dictionary<string, StatusResult> statuses) StatusAllIfChanged(string revision);

        Dictionary<string, ImportResult> ImportResult(params string[] ids);
        Dictionary<string, StatusResult> Import(params string[] ids);
        Dictionary<string, StatusResult> ImportAll();

        IEnumerable<string> WithFlag(params string[] ids);
        IEnumerable<string> WithFlagAll();

        Dictionary<string, StatusResult> SetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
        Dictionary<string, StatusResult> ClearFlags(params string[] ids);
        Dictionary<string, StatusResult> UnsetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
    }
}