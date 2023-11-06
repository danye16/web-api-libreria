using System;

namespace libreria_JDPC.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }







    }
}
