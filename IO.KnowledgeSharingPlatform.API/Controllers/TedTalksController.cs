using IO.KnowledgeSharingPlatform.Core.Model.Requests;
using IO.KnowledgeSharingPlatform.Core.Model.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IO.KnowledgeSharingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TedTalksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TedTalksController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetTedTalkResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json", Type = typeof(GetTedTalkResponse))]
        public async Task<ActionResult<GetTedTalkResponse>> Get([FromQuery] GetTedTalkRequest request)
        {
            return StatusCode((int)HttpStatusCode.OK, await _mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(PostTedTalkResponse), (int)HttpStatusCode.Created)]
        [Produces("application/json", Type = typeof(PostTedTalkResponse))]
        public async Task<ActionResult<PostTedTalkResponse>> Post(PostTedTalkRequest request)
        {
            return StatusCode((int)HttpStatusCode.Created, await _mediator.Send(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PutTedTalkResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json", Type = typeof(PutTedTalkResponse))]
        public async Task<ActionResult<PutTedTalkResponse>> Put(Guid id, PutTedTalkRequest request)
        {
            request.Id = id;
            return StatusCode((int)HttpStatusCode.OK, await _mediator.Send(request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteTedTalkResponse), (int)HttpStatusCode.OK)]
        [Produces("application/json", Type = typeof(DeleteTedTalkResponse))]
        public async Task<ActionResult<DeleteTedTalkResponse>> Delete(DeleteTedTalkRequest request)
        {
            return StatusCode((int)HttpStatusCode.OK, await _mediator.Send(request));
        }
    }
}
