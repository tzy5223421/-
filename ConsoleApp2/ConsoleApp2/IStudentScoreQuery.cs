using System.ServiceModel;
using System.ServiceModel.Web;

namespace ConsoleApp2
{
    [ServiceContract]
    public interface IStudentScoreQuery
    {
        [OperationContract]
        [WebGet(UriTemplate = "StudentScoreQuery/{name}", ResponseFormat = WebMessageFormat.Json)]
        StudentScore GetScore(string name);
    }
}
