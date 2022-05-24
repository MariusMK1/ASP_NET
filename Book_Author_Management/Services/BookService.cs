using Book_Author_Management.Data;
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
        public List<Book> GetAll()
        {
            return _dataContext.Books.ToList();
        }
        public void Add(Book book)
        {
            _dataContext.Books.Add(book);
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
