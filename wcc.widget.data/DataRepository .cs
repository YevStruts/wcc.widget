using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcc.widget.Infrastructure;
using static System.Formats.Asn1.AsnWriter;

namespace wcc.widget.data
{
    public class DataRepository : IDataRepository
    {
        public LiveScore? GetLiveScore(string liveScoreId)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                return session.Query<LiveScore>().FirstOrDefault(x => x.Id == liveScoreId);
            }
        }

        public bool SaveLiveScore(LiveScore LiveScore)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(LiveScore);
                session.SaveChanges();
            }
            return true;
        }

        public bool UpdateLiveScore(LiveScore liveScore)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                var liveScoreDto = session.Query<LiveScore>().FirstOrDefault(x => x.Id == liveScore.Id);
                if (liveScoreDto == null) return false;

                liveScoreDto.SideA = liveScore.SideA;
                liveScoreDto.SideB = liveScore.SideB;
                liveScoreDto.ScoreA = liveScore.ScoreA;
                liveScoreDto.ScoreB = liveScore.ScoreB;
                
                liveScoreDto.Width = liveScore.Width;
                liveScoreDto.MarginTop = liveScore.MarginTop;
                liveScoreDto.MarginRight = liveScore.MarginRight;

                session.SaveChanges();
            }
            return true;
        }

        public bool DeleteLiveScore(string liveScoreId)
        {
            using (IDocumentSession session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Delete(liveScoreId);
                session.SaveChanges();
            }
            return true;
        }
    }
}
