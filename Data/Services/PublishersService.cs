using libreria_JDPC.Data.Models;
using libreria_JDPC.Data.ViewModels;
using libreria_JDPC.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace libreria_JDPC.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        //Aqui vamos a tener un unico metodo para
        //agregar una nueva Editora en la BD.
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStarsWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un número",
                publisher.Name);
            var _publisher = new Publisher()
            {
                Name = publisher.Name

            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId) 
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()

                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }
        //MEtodo para eliminar un Publisher ´por medio de su id, tambien se borran los libros vinculados
        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null) 
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con el id_ {id} no existe!");
            }

        }
        private bool StringStarsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

    }
}
