using AutoMapper;
using BookStore.BookStoreApi.Application.DTOs;
using BookStore.BookStoreApi.Application.Service.Interfaces;
using BookStore.BookStoreApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Application.Service
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository { get; set; }
        private readonly IMapper mapper;
        public PersonService() { 
        
        }

        public Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            throw new NotImplementedException();
        }
    }
}
