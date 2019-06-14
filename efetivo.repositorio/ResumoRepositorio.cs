

namespace efetivo.repositorio
{

    using DataEngineer;
    using efetivo.entidades;
    using System.Threading.Tasks;

    public class ResumoRepositorio : BaseRepositorio<ResumoEntidade, EfetivoContext>
    {

        public ResumoRepositorio() :
            base(null)
        {

        }

        public ResumoRepositorio(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }

        public async Task<ResumoEntidade> GetResumo(int id_unidade)
        { 
            return this.Find(id_unidade); 
        }

        //public async Task<DataTable> ListarAlunosTurma(decimal id_unidade, decimal id_turma, decimal id_periodo)
        //{
        //    List<object> Param = new List<object>()
        //    {
        //        this.CreateOracleParameter("p_id_unidade", id_unidade),
        //        this.CreateOracleParameter("p_id_turma", id_turma),
        //        this.CreateOracleParameter("p_id_periodo", id_periodo),

        //        this.CreateOracleParameterResultset()
        //    };

        //    try
        //    {
        //        return await this.GetDataTableAsync("ACADEMICO.pc_portal.pr_listar_alunos_Unidade_turma", Param, CommandType.StoredProcedure);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
