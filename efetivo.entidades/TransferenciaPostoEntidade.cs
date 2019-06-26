

namespace efetivo.entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("transferencia_posto")]
    public partial class TransferenciaPostoEntidade
    {
        [Key]
        [Column("id_transferencia_posto")]
        public int IdTransferenciaPosto { get; set; }

        [Column("dt_transferencia")]
        public DateTime DataTransferencia { get; set; }

        [Column("id_posto_origem")]
        public int IdPostoOrigem { get; set; }

        [Column("id_posto_destino")]
        public int IdPostoDestino { get; set; }
        
        [Column("observacao")]
        public string  Observacao { get; set; }

        [Column("id_efetivo")]
        public int IdEfetivo { get; set; }

        [Column("id_efetivo_registro")]
        public int IdEfetivoResgistro { get; set; }

    }
}
