

namespace efetivo.entidades
{


    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("resumo")]
    public class ResumoEntidade
    {
        [Key]
        [Column("id_resumo")]
        public int Id { get; set; }

        [Column("qtde_masculino")]
        public int qtde_masculino { get; set; }

    }
}
