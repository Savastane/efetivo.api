﻿using System;
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

            var stringcon = "";

            optionsBuilder.UseNpgsql(stringcon);
            base.OnConfiguring(optionsBuilder);
        }



    }
}
