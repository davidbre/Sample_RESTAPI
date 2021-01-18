//*==========================================================================
//* Sample Code
//* Copyright (c) 2020 All Rights Reserved
//* Author : David Brennan
//* Email: davidbre@gmail.com
//*==========================================================================

using System.Collections.Generic;
using System.IO;
using System.Net;

namespace PMSummary.Library
{
    public class HTTPLibrary
    {
        //*--------------------------------------------------------------------------------------------*
        //* Name: GetJSON
        //* Parameters: 
        //*     url : URL of the web page to retrieve. ie:  https://www.endpoint.org/organizations
        //*--------------------------------------------------------------------------------------------*
        public static string GetJSON(string url, string acceptHeader = "application/json", Dictionary<string, string> headers = null)
        {
            string responseHtml = string.Empty;

            url = url.Trim();

            System.Net.HttpWebRequest request = null;
            System.Net.WebResponse response = null;

            // SSL-Certificate Validation
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };

            try
            {
                // Create the HttpWebRequest Object
                request = (System.Net.HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 1200000;

                request.Method = "GET";
                request.Accept = acceptHeader;
                request.ContentType = "text/html; charset=utf-8";

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }

                response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                responseHtml = reader.ReadToEnd();

                reader.Close();
                response.Close();


            }
            catch (System.Exception err)
            {
                responseHtml = err.Message;
            }

            return responseHtml;
        }

    }
}
