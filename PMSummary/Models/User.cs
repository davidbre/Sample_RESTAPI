
using Newtonsoft.Json;

namespace PMSummary.Models
{
    public class User
    {
        public int      id              { get; set; }
        public string   name            { get; set; }
        public string   email           { get; set; }
        public int      phoneCount      { get; set; }

        [JsonIgnore]
        public string organizationId { get; set; }

        public User()
        {
            // Initialized -1 helps identify situation where remote API is inaccessible. 
            phoneCount = -1;    
        }

    }
}
