using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.BookStoreApi.Domain.Entities;
using BookStore.BookStoreApi.Domain.Repositories;

namespace BookStore.BookStoreApi.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        //private readonly ApplicationDBContext
        Task<Person> IPersonRepository.CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        Task IPersonRepository.DeleteAsync(Person person)
        {
            throw new NotImplementedException();
        }

        Task IPersonRepository.EditAsync(Person person)
        {
            throw new NotImplementedException();
        }

        Task<Person> IPersonRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Person>> IPersonRepository.GetPeopleAsync()
        {
            throw new NotImplementedException();
        }
    }
}
