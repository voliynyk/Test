using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WcfService2.Exceptions
{
    public class RecordNotFoundException : FaultException 
    {
        public RecordNotFoundException(string ex)
            : base(ex)
        { }
    }
}