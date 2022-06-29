using System;
using Pariplay.DataAccessLayer.DataObjects;

namespace Pariplay.Models
{
    public class Team
    {
        public Team(TeamDTO entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}
