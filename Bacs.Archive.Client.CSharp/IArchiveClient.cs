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
        Task<IEnumerable<string>> ExistingAsync(params string[] ids);
        IEnumerable<string> ExistingAll();
        Task<IEnumerable<string>> ExistingAllAsync();

        Dictionary<string, StatusResult> Status(params string[] ids);
        Task<Dictionary<string, StatusResult>> StatusAsync(params string[] ids);
        Dictionary<string, StatusResult> StatusAll();
        Task<Dictionary<string, StatusResult>> StatusAllAsync();
        (string revision, Dictionary<string, StatusResult> statuses) StatusAllIfChanged(string revision);
        Task<(string revision, Dictionary<string, StatusResult> statuses)> StatusAllIfChangedAsync(string revision);

        Dictionary<string, ImportResult> ImportResult(params string[] ids);
        Task<Dictionary<string, ImportResult>> ImportResultAsync(params string[] ids);
        Dictionary<string, StatusResult> Import(params string[] ids);
        Task<Dictionary<string, StatusResult>> ImportAsync(params string[] ids);
        Dictionary<string, StatusResult> ImportAll();
        Task<Dictionary<string, StatusResult>> ImportAllAsync();

        IEnumerable<string> WithFlag(params string[] ids);
        Task<IEnumerable<string>> WithFlagAsync(params string[] ids);
        IEnumerable<string> WithFlagAll();
        Task<IEnumerable<string>> WithFlagAllAync();

        Dictionary<string, StatusResult> SetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
        Dictionary<string, StatusResult> ClearFlags(params string[] ids);
        Dictionary<string, StatusResult> UnsetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
    }
}