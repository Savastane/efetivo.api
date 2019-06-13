using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace efetivo.entidades
{
    public class ResumoContext : DbContext
    {
        public ResumoContext(DbContextOptions<ResumoContext> options) : base(options)
        {

        }

        public DbSet<ResumoEntidade> ResumoEntity { get; set; }

    }
}

