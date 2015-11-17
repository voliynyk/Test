using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService2.Entities;
using WcfService2.Exceptions;
using WcfService2.Model;

namespace WcfService2.Repositories
{
    public class PersonRepository : IRepository<PersonEntity>
    {
        public IList<PersonEntity> GetAll()
        {
            using (var ctx = new TestTaskEntities())
            {
                return ctx.Person.ToList();
            }
        }

        public PersonEntity GetRecord(int id)
        {
            using (var ctx = new TestTaskEntities())
            {
                var person = ctx.Person.Where(s => s.ID == id).FirstOrDefault();
                if (person != null)
                {
                    return person;
                }
                else
                {
                    throw new RecordNotFoundException("No Person record with ID = " + id);
                }
            }
        }

        public PersonEntity Add(PersonEntity person)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Person.Add(person);
                ctx.SaveChanges();
                return person;
            }
        }
        public PersonEntity Update(PersonEntity person)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Entry(person).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return person;
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new TestTaskEntities())
            {
                ctx.Person.Remove(GetRecord(id));
                ctx.SaveChanges();
            }
        }
    }
}