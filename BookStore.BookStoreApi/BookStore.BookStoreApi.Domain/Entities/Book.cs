using BookStore.BookStoreApi.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BookStoreApi.Domain.Entities
{
    public sealed class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Book(string title, string description, decimal price)
        {
            Validation(title, description, price);
        }

        public Book(int id, string title, string description, decimal price)
        {
            DomainValidationException.When(id < 0, "o Id do produto deve ser informado");
            Id = id;
            Validation(title, description, price);
        }

        private void Validation(string title, string description, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "O título deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(description), "A descrição deve ser informada");
            DomainValidationException.When(price <= 0, "Preço deve ter um válor válido");

            Title = title;
            Description = description;
            Price = price;

        }
    }
}
