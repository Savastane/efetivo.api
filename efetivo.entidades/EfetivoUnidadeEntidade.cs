

namespace efetivo.entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("EfetivoUnidade")]
    public partial class EfetivoUnidadeEntidade
    {
        

        [Key]
        [Column("id_efetivo_unidade")]
        public decimal IdEfetivoUnidade { get; set; }

        [Column("id_efetivo")]
        public decimal IdEfetivo { get; set; }

        [Column("id_unidade")]
        public decimal IdUnidade { get; set; }

        [Column("fl_ativo")]
        public string FlAtivo { get; set; }

        public virtual EfetivoEntity EfetivoEntidade { get; set; }
        public virtual UnidadeEntity UnidadeEntidade { get; set; }


    }
}
