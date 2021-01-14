
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
             BodyStyle = WebMessageBodyStyle.Wrapped,
             UriTemplate = "summary")]
        [return: MessageParameter(Name = "Data")]
        string MainProcess();
    }

}