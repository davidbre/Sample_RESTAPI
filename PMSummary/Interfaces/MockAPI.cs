//*==========================================================================
//* Sample Code
//* Copyright (c) 2020 All Rights Reserved
//* Author : David Brennan
//* Email: davidbre@gmail.com
//*==========================================================================

using System.Collections.Generic;
using Newtonsoft.Json;

using PMSummary.Library;
using PMSummary.Models;


namespace PMSummary.Interfaces
{
    class MockAPI
    {
        //===========================
        // ORGANIZATIONS
        //===========================
        public List<Organization> GetOrganizations()
        {
            var orglist = new List<Organization>();
            var endpoint = "https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations";

            try
            {
                var json = HTTPLibrary.GetJSON(endpoint);
                orglist = JsonConvert.DeserializeObject<List<Organization>>(json);
            }
            catch (System.Exception)
            {
                // Logging Goes Here
            }


            return orglist;
        }

        //===========================
        // USERS
        //===========================
        public List<User> GetUsersByOrganization(int orgid)
        {
            var userlist = new List<User>();
            var endpoint = $"https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/{orgid}/users";

            var json = HTTPLibrary.GetJSON(endpoint);
            try
            {          
                userlist = JsonConvert.DeserializeObject<List<User>>(json);
            }
            catch (System.Exception)
            {
                // Propogate API Error to JSON to Debug
                var user = new User();
                user.email = json;
                userlist.Add(user);
            }


            return userlist;
        }

        //===========================
        // PHONE NUMBERS
        //===========================
        public List<Phone> GetPhoneByUser(int orgid, int userid)
        {
            var phonelist = new List<Phone>();
            var endpoint = $"https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/{orgid}/users/{userid}/phones";

            try
            {
                var json = HTTPLibrary.GetJSON(endpoint);
                phonelist = JsonConvert.DeserializeObject<List<Phone>>(json);
            }
            catch (System.Exception)
            {
                // Logging Goes Here
            }


            return phonelist;
        }
    }
}
