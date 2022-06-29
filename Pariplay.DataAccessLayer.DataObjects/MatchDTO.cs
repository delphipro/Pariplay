using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pariplay.DataAccessLayer.DataObjects
{
    public class MatchDTO: BaseEntity
    {
        public int HostId { get; set; }
        public int VisitorId { get; set; }
        public int TeamHostResult { get; set; }
        public int TeamVisitorResult { get; set; }

        #region relations

        [ForeignKey(nameof(HostId))]
        public virtual TeamDTO Host { get; set; }

        [ForeignKey(nameof(VisitorId))]
        public virtual TeamDTO Visitor { get; set; }

        #endregion
    }
}
