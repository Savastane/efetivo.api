﻿

namespace efetivo.entity
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("vw_unidades_contigente")]
    public partial class UnidadesContigenteEntity
    {
        [Key]
        [Column("id_unidade")]
        public decimal IdUnidade { get; set; }
        
        [Column("nome_unidade")]
        public string  NomeUnidade { get; set; }

        [Column("regiao")]
        public string Regiao { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("uf")]
        public string UnidadeFederativa { get; set; }

        [Column("img_unidade")]
        public string ImagemUnidade { get; set; }

        [Column("contigente")]
        public int Contigente { get; set; }

    }
}
