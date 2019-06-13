

namespace efetivo.entidades
{


    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("resumo")]
    public class ResumoEntidade
    {
        [Key]
        [Column("id_resumo")]
        public long Id { get; set; }


        public string Name { get; set; }
        
    }
}
