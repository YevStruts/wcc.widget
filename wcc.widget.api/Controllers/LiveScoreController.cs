using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using wcc.widget.kernel.Models;
using wcc.widget.kernel.Models.Results;
using wcc.widget.kernel.RequestHandlers;

namespace wcc.widget.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiveScoreController
    {
        protected readonly ILogger<LiveScoreController>? _logger;
        protected readonly IMediator? _mediator;

        public LiveScoreController(ILogger<LiveScoreController>? logger, IMediator? mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<LiveScoreModel> Get(string id)
        {
            string liveScoreId = HttpUtility.UrlDecode(id);
            return await _mediator.Send(new GetLiveScoreQuery(liveScoreId));
        }

        [HttpPost]
        public async Task<SaveOrUpdateResult<LiveScoreModel>> Post(LiveScoreModel game)
        {
            return await _mediator.Send(new SaveOrUpdateLiveScoreQuery(game));
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            string gameId = HttpUtility.UrlDecode(id);
            return await _mediator.Send(new DeleteLiveScoreQuery(gameId));
        }
    }
}
