using BookStore.BookStoreApi.Application.DTOs;
using BookStore.BookStoreApi.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.CreateAsync(personDTO);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _personService.GetAsync();

            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _personService.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
