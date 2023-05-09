using BookStore.BookStoreApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Application.Service.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> GetAsync();
        Task<ResultService<PersonDTO>> GetByIdAsync(int id);

    }
}
