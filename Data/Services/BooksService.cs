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
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                Rate = book.Rate,
                PublisherId = book.PublisherID

            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        
            foreach(var id in book.AutorIDs) 
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();

            }
        }


        //Metodo para listar libros
        public List<Book> GetAllBks() => _context.Books.ToList();

        //Metodo para buscar un unico libro
        public BookWithAuthorsVM GetBookById(int bookid)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookid).Select(book => new BookWithAuthorsVM()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Genero = book.Genero,
                CoverUrl = book.CoverUrl,
                Rate = book.Rate,
                PublisherName = book.Publisher.Name,
                AutorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
        }
        //Método que nos permite modificar un libro que se encuentra en la BD
        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id== bookid);
            if (_book != null) 
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Genero = book.Genero;
                _book.CoverUrl = book.CoverUrl;
                _book.Rate = book.Rate;
                _context.SaveChanges();
            }
            return _book;
        }

        //Metodo para eliminar un libro de la BD
        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);
            if (_book != null) 
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    }
    
}
