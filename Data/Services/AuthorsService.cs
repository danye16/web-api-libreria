using libreria_JDPC.Data.Models;
using libreria_JDPC.Data.ViewModels;
using System;

namespace libreria_JDPC.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        //Aqui vamos a tener un unico metodo para
        //agregar libros a nuestra BD.
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
               FullName = author.FullName

            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
