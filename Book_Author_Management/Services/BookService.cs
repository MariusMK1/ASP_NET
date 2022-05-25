using Book_Author_Management.Data;
using Book_Author_Management.Dtos;
using Book_Author_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Author_Management.Services
{
    public class BookService
    {
        private DataContext _dataContext;

        public BookService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<BookDto> GetAll()
        {
            var entities = _dataContext.Books.ToList();
            return entities.Select(e => new BookDto
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
        }
        public void Add(BookDto bookDto)
        {
            Book entity = new Book
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId
            };

            _dataContext.Books.Add(entity);
            _dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Book book = _dataContext.Books.FirstOrDefault(b => b.Id == id);
            _dataContext.Books.Remove(book);
            _dataContext.SaveChanges();
        }
    }
}
