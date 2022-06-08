using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Application.Handlers
{
    public class DeleteTedTalkHandler : IRequestHandler<DeleteTedTalkRequest, DeleteTedTalkResponse>
    {
        private readonly ITedTalkService _tedTalkService;

        public DeleteTedTalkHandler(ITedTalkService tedTalkService)
        {
            _tedTalkService = tedTalkService ?? throw new ArgumentNullException(nameof(tedTalkService));
        }

        public Task<DeleteTedTalkResponse> Handle(DeleteTedTalkRequest request, CancellationToken cancellationToken)
        {
            _tedTalkService.Delete(request.Id);

            return Task.FromResult(new DeleteTedTalkResponse());
        }
    }
}
