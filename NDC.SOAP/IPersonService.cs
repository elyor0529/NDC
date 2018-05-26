using System.ServiceModel;
using System.Threading.Tasks;
using NDC.Common.ViewModels;

namespace NDC.SOAP
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        int Search(string email, SearchModel model); 
    }
}