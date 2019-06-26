

namespace efetivo.entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("transferencia_unidade")]
    public partial class TransferenciaUnidadeEntidade
    {
        [Key]
        [Column("id_transferencia_unidade")]
        public int IdTransferenciaUnidade { get; set; }

        [Column("dt_transferencia")]
        public DateTime DataTransferencia { get; set; }

        [Column("id_unidade_origem")]
        public int IdUnidadeOrigem { get; set; }

        [Column("id_unidade_destino")]
        public int IdUnidadeDestino { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }

        [Column("id_efetivo")]
        public int IdEfetivo { get; set; }

        [Column("id_efetivo_registro")]
        public int IdEfetivoResgistro { get; set; }


    }
}
