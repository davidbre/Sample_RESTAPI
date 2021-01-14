using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace PMSummary.Interfaces
{
    public class MockAPISummarySvc : IMockAPISummary
    {
        //==================================================================
        // MainProcess()
        // Call Mock API and create JSON Summary of blacklisted phones by Company.
        //==================================================================
        public string MainProcess()
        {
            var mockapi = new MockAPI();
            var orgSummary = mockapi.GetOrganizations();

            // Loop Thru Organizations
            foreach (var o in orgSummary)
            {
                Console.WriteLine(o.id);
                // Get Users
                o.users = mockapi.GetUsersByOrganization(o.id);

                // Loop Thru Users
                foreach (var u in o.users)
                {
                    var phones = mockapi.GetPhoneByUser(o.id, u.id);

                    u.phoneCount = phones.Count();
                    o.blacklistTotal += phones.Where(x => x.blacklist == true).Count();
                    o.totalCount += u.phoneCount;
                }

            }

            // DEBUG OUTPUT
            Console.WriteLine(JsonConvert.SerializeObject(orgSummary, Formatting.Indented));


            // JSON TO CLIENT
            var jsonresult = JsonConvert.SerializeObject(orgSummary, Formatting.None);
            return jsonresult;
        }
    }
}