using IO.KnowledgeSharingPlatform.Core.Model.Enums;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Core.Model.Requests
{
    public class GetTedTalkRequest : IRequest<GetTedTalkResponse>
    {
        public TedTalkFilterType TedTalkFilter { get; set; }
        public string SearchQuery { get; set; }
    }
}
