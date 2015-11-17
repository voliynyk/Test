using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService2.Entities
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public List<Person> Persons { get; set; }
    }
}