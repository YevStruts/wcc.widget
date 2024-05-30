using AutoMapper;
using MediatR;
using wcc.widget.data;
using wcc.widget.Infrastructure;
using wcc.widget.kernel.Helpers;
using wcc.widget.kernel.Models;
using wcc.widget.kernel.Models.Results;

namespace wcc.widget.kernel.RequestHandlers
{
    public class GetLiveScoreQuery : IRequest<LiveScoreModel>
    {
        public string LiveScoreId { get; set; }

        public GetLiveScoreQuery(string liveScoreId)
        {
            LiveScoreId = liveScoreId;
        }
    }

    public class SaveOrUpdateLiveScoreQuery : IRequest<SaveOrUpdateResult<LiveScoreModel>>
    {
        public LiveScoreModel LiveScore { get; set; }

        public SaveOrUpdateLiveScoreQuery(LiveScoreModel liveScore)
        {
            this.LiveScore = liveScore;
        }
    }

    public class DeleteLiveScoreQuery : IRequest<bool>
    {
        public string LiveScoreId { get; set; }

        public DeleteLiveScoreQuery(string liveScoreId)
        {
            this.LiveScoreId = liveScoreId;
        }
    }

    public class LiveScoreHandler : IRequestHandler<GetLiveScoreQuery, LiveScoreModel>,
        IRequestHandler<SaveOrUpdateLiveScoreQuery, SaveOrUpdateResult<LiveScoreModel>>,
        IRequestHandler<DeleteLiveScoreQuery, bool>
    {
        private readonly IDataRepository _db;
        private readonly IMapper _mapper = MapperHelper.Instance;

        public LiveScoreHandler(IDataRepository db)
        {
            _db = db;
        }

        public async Task<LiveScoreModel> Handle(GetLiveScoreQuery request, CancellationToken cancellationToken)
        {
            var game = _db.GetLiveScore(request.LiveScoreId);
            return _mapper.Map<LiveScoreModel>(game);
        }

        public async Task<SaveOrUpdateResult<LiveScoreModel>> Handle(SaveOrUpdateLiveScoreQuery request, CancellationToken cancellationToken)
        {
            bool success = false;
            LiveScoreModel value = request.LiveScore;

            LiveScore liveScore = _mapper.Map<LiveScore>(request.LiveScore);
            if (string.IsNullOrEmpty(liveScore.Id))
            {
                success = _db.SaveLiveScore(liveScore);
                if (success)
                {
                    value = _mapper.Map<LiveScoreModel>(liveScore);
                }
            }
            else
            {
                success = _db.UpdateLiveScore(liveScore);
                if (success)
                {
                    value = _mapper.Map<LiveScoreModel>(liveScore);
                }
            }
            return new SaveOrUpdateResult<LiveScoreModel>() { Success = success, Value = value };
        }

        public async Task<bool> Handle(DeleteLiveScoreQuery request, CancellationToken cancellationToken)
        {
            return _db.DeleteLiveScore(request.LiveScoreId);
        }
    }
}
