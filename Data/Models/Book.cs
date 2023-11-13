using System;
using System.Collections.Generic;

namespace libreria_JDPC.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public int? Rate { get; set; }

        //Propiedades de navegacion
        //(en esta parte es donde especificamos las relaciones)
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Book_Author> Book_Authors { get; set; }






    }
}
