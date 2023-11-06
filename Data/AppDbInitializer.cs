using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using libreria_JDPC.Data.Models;
using System.Security.Cryptography.X509Certificates;
using System;

namespace libreria_JDPC.Data
{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope =applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1st Book Title",
                        Descripcion = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Biography",
                        Autor = "1st Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    },
                    new Book()
                    {
                        Titulo = "2st Book Title",
                        Descripcion = "2st Book Description",
                        IsRead = true,
                        Genero = "Biography",
                        Autor = "2st Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,

                    });
                    context.SaveChanges();
                    
                   
                }
            }
        }
    }
}
