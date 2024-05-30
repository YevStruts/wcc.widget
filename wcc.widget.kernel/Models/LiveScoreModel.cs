using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wcc.widget.Infrastructure;

namespace wcc.widget.kernel.Models
{
    public class LiveScoreModel
    {
        public string? Id { get; set; }
        public string? SideA { get; set; }
        public string? SideB { get; set; }
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }

        #region settings
        public int Width { get; set; }
        public int MarginTop { get; set; }
        public int MarginRight { get; set; }
        #endregion settings
    }
}
