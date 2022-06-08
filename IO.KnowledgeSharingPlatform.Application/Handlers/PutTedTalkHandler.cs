using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Application.Handlers
{
    public class PutTedTalkHandler : IRequestHandler<PutTedTalkRequest, PutTedTalkResponse>
    {
        private readonly ITedTalkService _tedTalkService;

        public PutTedTalkHandler(ITedTalkService tedTalkService)
        {
            _tedTalkService = tedTalkService ?? throw new ArgumentNullException(nameof(tedTalkService));
        }

        public async Task<PutTedTalkResponse> Handle(PutTedTalkRequest request, CancellationToken cancellationToken)
        {
            var tedTalk = _tedTalkService.Where(a => a.Id == request.Id).FirstOrDefault();
            tedTalk.Title = request.Title;
            tedTalk.Author = request.Author;
            tedTalk.Likes = request.Likes;
            tedTalk.Link = request.Link;
            tedTalk.Views = request.Views;
            tedTalk.Date = request.Date;

            _tedTalkService.Update(tedTalk);

            return new PutTedTalkResponse() { TedTalk = tedTalk };
        }
    }
}
