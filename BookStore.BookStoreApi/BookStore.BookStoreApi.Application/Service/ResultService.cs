using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Application.Service
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }
        public static ResultService RequestError (string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSuccess = false,
                Message = message,
                Errors = validationResult.Errors.Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { IsSuccess = false, Message = message };
        public static ResultService Fail<T>(string message) => new ResultService<T> { IsSuccess = false, Message = message };

        public static ResultService OK(string message) => new ResultService { IsSuccess = true, Message = message };
        public static ResultService<T> OK<T>(T data) => new ResultService<T> { IsSuccess = true, Data = data };
    }
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
