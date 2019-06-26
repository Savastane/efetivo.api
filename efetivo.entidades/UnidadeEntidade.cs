

namespace efetivo.entidades
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("unidade")]
    public partial class UnidadeEntidade
    {
        [Key]
        [Column("id_unidade")]
        public int IdUnidade { get; set; }

        [Column("nome")]
        public string  Nome { get; set; }

        [Column("sigla")]
        public string Sigla { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }
        
        [Column("numero")]
        public string Numero { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("estado")]
        public string Estado { get; set; }

        [Column("uf")]
        public string UF { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        [Column("latitude")]
        public decimal Latitude { get; set; }

        [Column("logitude")]
        public decimal Longitude { get; set; }
    }
}
