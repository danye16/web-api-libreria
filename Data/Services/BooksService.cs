using libreria_JDPC.Data.ViewModels;
using libreria_JDPC.Data.Models;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;

namespace libreria_JDPC.Data.Services
{
    public class BooksService 
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        //Aqui vamos a tener un unico metodo para
        //agregar libros a nuestra BD.
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                Rate = book.Rate

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        //Metodo para listar libros
        public List<Book> GetAllBks() => _context.Books.ToList();

        //para un unico libro
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.Id== bookid);
        
    }
    
}
