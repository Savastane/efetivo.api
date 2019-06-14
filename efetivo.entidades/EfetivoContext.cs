using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace efetivo.entidades
{
    public class EfetivoContext : DbContext
    {
        public EfetivoContext(DbContextOptions<EfetivoContext> options) : base(options)
        {

        }

        public DbSet<ResumoEntidade> ResumoEntity { get; set; }


        /*
        public GenericContext()
        {
            Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(ConfigurationManager.AppSettings["dbefetivo"]);
            base.OnConfiguring(optionsBuilder);
        }



    }
}

