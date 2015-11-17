using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService2.Entities;
using WcfService2.Exceptions;
using WcfService2.Model;

namespace WcfService2.Repositories
{
    public class AddressRepository : IRepository<AddressEntity>
    {
        public IList<AddressEntity> GetAll()
        {
            using (var ctx = new TestTaskEntities())
            {
                return ctx.Address.ToList();
            }
        }

        public AddressEntity GetRecord(int id)
        {
            using (var ctx = new TestTaskEntities())
            {
                var address = ctx.Address.Where(s => s.ID == id).FirstOrDefault();
                if (address != null)
                {
                    return address;
                }
                else
                {
                    throw new RecordNotFoundException("No Address record with ID = " + id);
                }
            }
        }

        public AddressEntity Add(AddressEntity address)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Address.Add(address);
                ctx.SaveChanges();
                return address;
            }
        }
        public AddressEntity Update(AddressEntity address)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Entry(address).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return address;
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Address.Remove(GetRecord(id));
                ctx.SaveChanges();
            }
        }
    }
}