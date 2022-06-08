using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Application.Handlers
{
    public class GetTedTalkHandler : IRequestHandler<GetTedTalkRequest, GetTedTalkResponse>
    {
        private readonly ITedTalkService _tedTalkService;

        public GetTedTalkHandler(ITedTalkService tedTalkService)
        {
            _tedTalkService = tedTalkService ?? throw new ArgumentNullException(nameof(tedTalkService));
        }

        public Task<GetTedTalkResponse> Handle(GetTedTalkRequest request, CancellationToken cancellationToken)
        {
            var response = new GetTedTalkResponse();

            switch (request?.TedTalkFilter)
            {
                case Core.Model.Enums.TedTalkFilterType.Author:
                    response.TedTalks = _tedTalkService.Where(a => a.Author.Contains(request.SearchQuery)).ToList();
                    break;
                case Core.Model.Enums.TedTalkFilterType.Title:
                    response.TedTalks = _tedTalkService.Where(a => a.Title.Contains(request.SearchQuery)).ToList();
                    break;
                case Core.Model.Enums.TedTalkFilterType.Views:
                    response.TedTalks = _tedTalkService.Where(a => a.Views.Contains(request.SearchQuery)).ToList();
                    break;
                case Core.Model.Enums.TedTalkFilterType.Likes:
                    response.TedTalks = _tedTalkService.Where(a => a.Likes.Contains(request.SearchQuery)).ToList();
                    break;
            }

            return Task.FromResult(response);
        }
    }
}
