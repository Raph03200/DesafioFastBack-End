using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioFast.models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFast.DataContext 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
        public DbSet<ColaboradorModel> DbColaborador { get; set;}
        public DbSet<WorkshopModel> DbWorkshop { get; set;}
        public DbSet<PresencaModel> DbPresenca { get; set; }
    }
}