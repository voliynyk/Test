using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Entities;

namespace WcfService2.Interfaces
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        IList<Person> GetPersonList();
        [OperationContract]
        Person GetPerson(int id);
        [OperationContract]
        void AddPerson(Person person);
        [OperationContract]
        void UpdatePerson(Person person);
        [OperationContract]
        void DeletePerson(int id);
    }
}
