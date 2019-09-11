

namespace efetivo.entity
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("resumo")]
    public partial class ResumoEntity
    {
        [Key]
        [Column("id_resumo")]
        public int Id { get; set; }

        [Column("qtde_masculino")]
        public int qtde_masculino { get; set; }

    }
}
