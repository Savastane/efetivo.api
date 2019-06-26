using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using DataEngineer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace efetivo.entidades
{
    public class EfetivoContext : DbContextRepositorio
    {
        /*
        public EfetivoContext(DbContextOptions<EfetivoContext> options) : base(options)
        {

        }
        */
        public DbSet<ResumoEntidade> ResumoEntity { get; set; }
        public DbSet<UsuarioEntidade> UsuarioEntity { get; set; }
        public DbSet<UnidadesContigenteEntidade> UnidadesContigenteEntity { get; set; }


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

            //var builder = new ConfigurationBuilder()             .    
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json");

            //Configuration = builder.Build();
            //ConfigurationManager.ConnectionStrings
            //ConfigurationManager.AppSettings["dbefetivo"]
            //"ConfigurationManager.AppSettings["dbefetivo"];

            var stringcon = "Host=ec2-107-20-230-70.compute-1.amazonaws.com;Port=5432;Username=tjsmvoatysaelx;Password=a908f03648bd69276ea98e9e97266c2c71cebaa75d6dba7b9c50b1337b810dbc;Database=d98olp1q81llpp;SSL Mode=Require;Trust Server Certificate=true";

            optionsBuilder.UseNpgsql(stringcon);
            base.OnConfiguring(optionsBuilder);
        }



    }
}

