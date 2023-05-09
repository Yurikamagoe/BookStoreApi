using AutoMapper;
using BookStore.BookStoreApi.Application.DTOs;
using BookStore.BookStoreApi.Application.DTOs.Validations;
using BookStore.BookStoreApi.Application.Service.Interfaces;
using BookStore.BookStoreApi.Domain.Entities;
using BookStore.BookStoreApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper) { 
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

            var result = new PersonDTOValidator().Validate(personDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.OK<PersonDTO>(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return ResultService.OK<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return ResultService.OK(_mapper.Map<PersonDTO>(person));
        }
    }
}
