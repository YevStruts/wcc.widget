using AutoMapper;
using MediatR;
using wcc.widget.data;
using wcc.widget.kernel.Helpers;
using wcc.widget.kernel.Models;

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

    public class LiveScoreHandler : IRequestHandler<GetLiveScoreQuery, LiveScoreModel>
    {
        private readonly IDataRepository _db;
        private readonly IMapper _mapper = MapperHelper.Instance;

        public LiveScoreHandler(IDataRepository db)
        {
            _db = db;
        }

        public async Task<LiveScoreModel> Handle(GetLiveScoreQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
