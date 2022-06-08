using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Core.Model.Requests
{
    public class PutTedTalkRequest : TedTalk, IRequest<PutTedTalkResponse>
    {
    }
}
