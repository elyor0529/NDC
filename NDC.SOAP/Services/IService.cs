using System.Collections.Generic;
using NDC.SOAP.Models;

namespace NDC.SOAP.Services
{
    public interface IService
    {
        void BatchSend(string destination, IEnumerable<Person> peoples);
    }
}