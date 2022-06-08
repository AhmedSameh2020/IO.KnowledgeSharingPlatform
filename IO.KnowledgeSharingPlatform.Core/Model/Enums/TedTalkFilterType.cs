using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IO.KnowledgeSharingPlatform.Core.Model.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TedTalkFilterType
    {
        Author = 0,
        Title = 1,
        Views = 2,
        Likes = 3
    }
}
