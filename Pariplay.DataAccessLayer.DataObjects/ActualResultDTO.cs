using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pariplay.DataAccessLayer.DataObjects
{
    public class ActualResultDTO: BaseEntity
    {
        public int TeamId { get; set; }

        public int Wins { get; set; }

        public int Equality { get; set; }

        public int Losses { get; set; }

        public DateTime UpdatedTimestamp { get; set; }

        #region relations

        [ForeignKey(nameof(TeamId))]
        public virtual TeamDTO Team { get; set; }

        #endregion
    }
}
