using Book_Author_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Author_Management.Dtos
{
    public class BookDto
    {
        public Book Book { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
