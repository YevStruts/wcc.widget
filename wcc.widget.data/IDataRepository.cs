using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcc.widget.Infrastructure;

namespace wcc.widget.data
{
    public interface IDataRepository
    {
        LiveScore? GetLiveScore(string liveScoreId);
        bool SaveLiveScore(LiveScore LiveScore);
        bool UpdateLiveScore(LiveScore LiveScore);
        bool DeleteLiveScore(string LiveScoreId);
    }
}
