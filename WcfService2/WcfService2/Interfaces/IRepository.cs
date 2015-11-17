using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Entities;

namespace WcfService2
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetRecord(int id);
        T Add(T person);
        T Update(T person);
        void Delete(int id);
    }
}
