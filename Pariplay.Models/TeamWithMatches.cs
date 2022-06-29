using System;
using System.Collections.Generic;

namespace Pariplay.Models
{
    public class TeamWithMatches
    {
        public string Name { get; set; }

        public ICollection<Match> Matches { get; set; }
    }
}
