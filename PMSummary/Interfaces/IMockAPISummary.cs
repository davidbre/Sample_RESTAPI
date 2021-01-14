
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