using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using infra.generics.repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace efetivo.entity
{
    public class EfetivoContext : DbContextRepositorio
    {

        

        /*
        public EfetivoContext(DbContextOptions<EfetivoContext> options) : base(options)
        {

        }
        
             */
        public DbSet<EfetivoEntity> EfetivoEntity { get; set; }
        public DbSet<ResumoEntity> ResumoEntity { get; set; }
        public DbSet<UsuarioEntity> UsuarioEntity { get; set; }
        public DbSet<UnidadeEntity> UnidadeEntity { get; set; }
        public DbSet<UnidadesContigenteEntity> UnidadesContigenteEntity { get; set; }


        /*
        public GenericContext()
        {
            Database.EnsureCreated();//Cria o banco de dados, caso o mesmo não exista
        }
        */
        public static IConfigurationRoot Configuration { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            /*
            optionsBuilder.UseInMemoryDatabase(databaseName: "database_name");
            */

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var stringcon = Configuration["ConnectionStrings:dbefetivo"];

            bool memory = Convert.ToBoolean( Configuration["DataBase:Memory"]);

            if (memory)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "database_name");
            }
            else
            {
                optionsBuilder.UseNpgsql(stringcon);
            }
            

            base.OnConfiguring(optionsBuilder);
        }



    }
}

