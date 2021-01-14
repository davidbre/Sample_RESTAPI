
using System.Collections.Generic;

namespace PMSummary.Models
{
    public class Organization
    {
        public int          id              { get; set; }
        public string       name            { get; set; }

        public int          blacklistTotal  { get; set; }
        public int          totalCount      { get; set; }
        public List<User>   users           { get; set; }

        public Organization()
        {
            // Initialization
            blacklistTotal  = 0;
            totalCount      = 0;
            users           = new List<User>();
        }

    }
}

