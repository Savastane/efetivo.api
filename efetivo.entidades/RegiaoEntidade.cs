

namespace efetivo.entidades
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("regiao")]
    public partial class RegiaoEntidade
    {
        [Key]
        [Column("id_regiao")]
        public int IdPosto { get; set; }

        [Column("nome")]
        public string  Nome { get; set; }


        
    }
}
