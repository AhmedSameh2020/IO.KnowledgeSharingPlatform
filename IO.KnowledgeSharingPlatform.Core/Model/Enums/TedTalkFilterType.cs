using System.Text.Json.Serialization;

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
