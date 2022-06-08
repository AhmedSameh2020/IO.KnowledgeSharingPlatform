using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Application.Handlers
{
    public class PostTedTalkHandler : IRequestHandler<PostTedTalkRequest, PostTedTalkResponse>
    {
        private readonly ITedTalkService _tedTalkService;

        public PostTedTalkHandler(ITedTalkService tedTalkService)
        {
            _tedTalkService = tedTalkService ?? throw new ArgumentNullException(nameof(tedTalkService));
        }

        public async Task<PostTedTalkResponse> Handle(PostTedTalkRequest request, CancellationToken cancellationToken)
        {
            return new PostTedTalkResponse() { TedTalk = _tedTalkService.Add(request.TedTalk) };
        }
    }
}
