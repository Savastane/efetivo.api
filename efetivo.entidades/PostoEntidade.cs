

namespace efetivo.entidades
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("posto")]
    public partial class PostoEntidade
    {
        [Key]
        [Column("id_posto")]
        public int IdPosto { get; set; }

        [Column("nome")]
        public string  Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }


        [Column("uri_img_posto")]
        public string uri_image { get; set; }


        
    }
}
