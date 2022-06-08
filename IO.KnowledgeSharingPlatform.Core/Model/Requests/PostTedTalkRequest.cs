﻿using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;

namespace IO.KnowledgeSharingPlatform.Core.Model.Requests
{
    public class PostTedTalkRequest : IRequest<PostTedTalkResponse>
    {
        public TedTalk TedTalk { get; set; }
    }
}
