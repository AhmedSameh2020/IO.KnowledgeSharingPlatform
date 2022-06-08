using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Core.Model.Requests
{
    public class DeleteTedTalkRequest : IRequest<DeleteTedTalkResponse>
    {
        public Guid Id { get; set; }
    }
}
