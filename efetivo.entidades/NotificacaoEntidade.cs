

namespace efetivo.entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("notificação")]
    public partial class NotificacaoEntidade
    {
        [Key]
        [Column("id_notificacao")]
        public int IdNotificacao { get; set; }

        [Column("dt_notificacao")]
        public DateTime  DataNotificacao { get; set; }

        [Column("mensagem_origem")]
        public string MensagemOrigem { get; set; }

        [Column("dt_resposta")]
        public DateTime DataResposta { get; set; }

        [Column("mensagem_resposta")]
        public string MensagemResposta { get; set; }


        [Column("fl_notificacao")]
        public string flg_notificacao { get; set; }


        [Column("id_efetivo_origem")]
        public int IdEfetivoOrigem { get; set; }

        [Column("id_efetivo_resposta")]
        public int IdEfetivoResposta { get; set; }






    }
}
