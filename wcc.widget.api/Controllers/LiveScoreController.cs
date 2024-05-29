using MediatR;
using Microsoft.AspNetCore.Mvc;
using wcc.widget.kernel.Models;
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

        // [HttpPost, Route("Save")]
        // public Task Save(GameModel model)
        // {
        //     return _mediator.Send(new SaveGameQuery(model));
        // }
    }
}
