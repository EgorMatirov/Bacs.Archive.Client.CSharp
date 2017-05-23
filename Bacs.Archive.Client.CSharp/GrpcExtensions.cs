using System.Collections.Generic;
using System.Linq;
using Bacs.Archive.Problem;
using Google.Protobuf.Collections;

namespace Bacs.Archive.Client.CSharp
{
    internal static class GrpcExtensions
    {
        public static Dictionary<string, T> ToDictionary<T>(this MapField<string, T> mapField)
        {
            return mapField.ToDictionary(x => x.Key, x => x.Value);
        }

        public static IdSet IdSetFromIds(IEnumerable<string> ids)
        {
            return new IdSet {Id = {ids}};
        }
    }
}