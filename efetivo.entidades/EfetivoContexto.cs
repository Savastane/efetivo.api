using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace efetivo.entidades
{
    public class EfetivoContexto : DbContext
    {
        public EfetivoContexto(DbContextOptions<EfetivoContexto> options) : base(options)
        {
        }

        public DbSet<ResumoEntidade> ResumoLista { get; set; }

    }
}

