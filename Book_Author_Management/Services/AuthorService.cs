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
    public class AuthorService
    {
        private DataContext _dataContext;

        public AuthorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<AuthorDto> GetAll()
        {
            List<Author> entities = _dataContext.Authors.Include(si => si.Books).ToList();
            var dtos = entities.Select(x => new AuthorDto
            {
                Id = x.Id,
                Name = x.Name,
                Books = x.Books.Select(b => new BookDto
                {
                    Id = b.Id,
                    Name = b.Name,
                }).ToList()
            }).ToList();
            return dtos;
        }
        public void Add(Author author)
        {
            _dataContext.Authors.Add(author);
            _dataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Author author = _dataContext.Authors.FirstOrDefault(a => a.Id == id);
            _dataContext.Authors.Remove(author);
            _dataContext.SaveChanges();
        }
    }
}
