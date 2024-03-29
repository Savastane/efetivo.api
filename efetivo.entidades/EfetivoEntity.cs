﻿

namespace efetivo.entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("efetivo")]
    public partial class EfetivoEntity
    {
        public EfetivoEntity()
        {
            
            this.EfetivoUnidadeEntidade = new HashSet<EfetivoUnidadeEntidade>();
        }


        [Key]
        [Column("id_efetivo")]
        public decimal IdEfetivo { get; set; }

        [Column("nome")]
        public string  Nome { get; set; }

        [Column("gerero")]
        public string Genero { get; set; }

        [Column("ddd_celular")]
        public string DDD_Celular { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("cpf")]
        public string CPF { get; set; }
        
        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("matricula")]
        public string Matricula { get; set; }
        
        [Column("id_posto")]
        public int idPosto { get; set; }

        [Column("id_unidade")]
        public decimal idUnidade { get; set; }

        [Column("fl_situacao")]
        public string flag_situacao { get; set; }

        [Column("fl_perfil")]
        public string flag_perfil { get; set; }

        public virtual ICollection<EfetivoUnidadeEntidade> EfetivoUnidadeEntidade { get; set; }


    }
}
