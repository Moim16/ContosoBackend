using System;
using System.Collections.Generic;
using System.Text;

/*Se agregan estos using*/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Contoso.Models.Entities;
/*********************/

namespace Contoso.DAL.EF
{
    /*Este hereda del DBContext*/
    public class ContosoContext : DbContext
    {
        /*Se crea un constructor*/
        public ContosoContext()
        {

        }
        /*Se crea un constructor con parametros*/
        /*Estas opciones tendran la cadena de conexion, que base de datos cuando se haga el middleware*/
        public ContosoContext(DbContextOptions<ContosoContext> options):base(options)
        {
            try
            {
                Database.Migrate(); /*Para cambiar tu modelo y luego la base de datos*/
            }
            catch
            {
                throw;
            }
        }


        /*Si se me olvido aplicar la configuracion sobreescribimos con las configuraciones
         * mediante un middleware usesqlserver*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ContosoDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        /*Ahora creamos los DBSet*/
        /*El primer DBSet va estar vinculado a student*/
        /*El que esta en plural sera el nombre de la tabla(Students)*/
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
