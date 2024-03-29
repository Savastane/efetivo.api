﻿

namespace efetivo.entity
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("vw_usuario")]
    public partial class UsuarioEntity
    {
        [Key]
        [Column("id_usuario")]
        public decimal IdUsuario { get; set; }

        [Column("nome")]
        public string  Nome { get; set; }

        [Column("matricula")]
        public string Matricula { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("posto")]
        public string Posto { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("uri_img_posto")]
        public string uri_img_posto { get; set; }


        [NotMapped]
        public string Token { get; set; }
        
    }
}
