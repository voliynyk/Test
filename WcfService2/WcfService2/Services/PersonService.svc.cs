using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Entities;
using WcfService2.Interfaces;
using WcfService2.Model;
using WcfService2.Repositories;

namespace WcfService2.Services
{
    public class PersonService : IPersonService
    {
        IRepository<PersonEntity> personRepository = new PersonRepository();
        IRepository<AddressEntity> addressRepository = new AddressRepository();

        public IList<Person> GetPersonList()
        {
            return personRepository.GetAll().Select(s => ConvertToPerson(s)).ToList();
        }

        public Person GetPerson(int id)
        {
            return ConvertToPerson(personRepository.GetRecord(id));
        }

        public void AddPerson(Person person)
        {
            PersonEntity personToAdd = new PersonEntity();
            personToAdd.Name = person.Name;
            personToAdd.Email = person.Email;
            foreach (var addressId in person.Addresses)
            {
                personToAdd.Address.Add(addressRepository.GetRecord(addressId));
            }
            personRepository.Add(personToAdd);
        }

        public void UpdatePerson(Person person)
        {
            PersonEntity personToUpdate = personRepository.GetRecord(person.ID);
            personToUpdate.Address.Clear();
            //personToUpdate.Name = person.Name;
            personToUpdate.Email = person.Email;
            foreach (var addressId in person.Addresses)
            {
                personToUpdate.Address.Add(addressRepository.GetRecord(addressId));
            }
            personRepository.Update(personToUpdate);
        }

        public void DeletePerson(int id)
        {
            personRepository.Delete(id);
        }

        private Person ConvertToPerson(PersonEntity person)
        {
            return new Person() { ID = person.ID, Name = person.Name, Email = person.Email };
        }
    }
}
