//*==========================================================================
//* Sample Code
//* Copyright (c) 2020 All Rights Reserved
//* Author : David Brennan
//* Email: davidbre@gmail.com
//*==========================================================================

using System.ServiceModel;
using System.ServiceModel.Web;


namespace PMSummary.Interfaces
{
    [ServiceContract]
    public interface IMockAPISummary
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "summary")]
        [return: MessageParameter(Name = "data")]
        string MainProcess();
    }

}