using System.Data.SqlClient;
using System.Data;
using SiteCurriculo.Models;

namespace SiteCurriculo.DAO
{
	public class CurriculoDAO
	{

		private SqlParameter[] CriarParametros(CurriculoViewModel curriculo)
		{
			SqlParameter[] parametros = new SqlParameter[9];
			parametros[0] = new SqlParameter("cpf", curriculo.cpf);
			parametros[1] = new SqlParameter("nome", curriculo.nome);
			parametros[2] = new SqlParameter("endereco", curriculo.endereco);
			parametros[3] = new SqlParameter("telefone", curriculo.telefone);
			parametros[4] = new SqlParameter("pretencao_salarial", curriculo.pretencao_salarial);
			parametros[5] = new SqlParameter("cargo_pretendido", curriculo.cargo_pretendido);
			parametros[6] = new SqlParameter("formacao_academica", curriculo.formacao_academica);
			if (curriculo.experiencia_proficional == null)
				parametros[7] = new SqlParameter("experiencia_proficional", DBNull.Value);
			else
				parametros[7] = new SqlParameter("experiencia_proficional", curriculo.experiencia_proficional);
			if (curriculo.idiomas == null)
				parametros[8] = new SqlParameter("idiomas", DBNull.Value);
			else
				parametros[8] = new SqlParameter("idiomas", curriculo.idiomas);
			return parametros;

		}

		private CurriculoViewModel MontarCurriculo(DataRow registro)
		{
			CurriculoViewModel curriculo = new CurriculoViewModel();
			curriculo.cpf = Convert.ToString(registro["cpf"]);
			curriculo.nome = Convert.ToString(registro["nome"]);
			curriculo.endereco = Convert.ToString(registro["endereco"]);
			curriculo.telefone = Convert.ToString(registro["telefone"]);
			curriculo.pretencao_salarial = Convert.ToDecimal(registro["pretencao_salarial"]);
			curriculo.cargo_pretendido = Convert.ToString(registro["cargo_pretendido"]);
			curriculo.formacao_academica = Convert.ToString(registro["formacao_academica"]);
			curriculo.experiencia_proficional = Convert.ToString(registro["experiencia_proficional"]);
			curriculo.idiomas = Convert.ToString(registro["idiomas"]);

			return curriculo;
		}

		public void Inserir(CurriculoViewModel curriculo)
		{
			string sql = "insert into Curriculo(cpf, nome, endereco, telefone, pretencao_salarial, cargo_pretendido,formacao_academica ,experiencia_proficional, idiomas)" +
			"values(@cpf, @nome, @endereco, @telefone, @pretencao_salarial, @cargo_pretendido,@formacao_academica, @experiencia_proficional, @idiomas)";

			HelperDAO.ExecutarSQL(sql, CriarParametros(curriculo));
		}

		public void Excluir(string cpf)
		{
			string sql = "delete from Curriculo where cpf = " + cpf;

			HelperDAO.ExecutarSQL(sql, null);
		}

		public void Alterar(CurriculoViewModel curriculo)
		{
            string sql = "update Curriculo set nome = @nome, telefone = @telefone, " +
             "pretencao_salarial = @pretencao_salarial, " +
             "cargo_pretendido = @cargo_pretendido, formacao_academica = @formacao_academica, " +
             "experiencia_proficional = @experiencia_proficional, " +
             "idiomas = @idiomas " +
             "where cpf = @cpf";

            HelperDAO.ExecutarSQL(sql, CriarParametros(curriculo));


		}

		public CurriculoViewModel Consulta(string cpf)
		{
			string sql = "select * from Curriculo where cpf = " + cpf;

			DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
			if (tabela.Rows.Count == 0)
			{
				return null;
			}
			else
			{
				return MontarCurriculo(tabela.Rows[0]);
			}
		}
		public List<CurriculoViewModel> Listagem()
		{
			List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
			string sql = "select * from Curriculo order by Nome ";

			DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
			foreach (DataRow dr in tabela.Rows)
				lista.Add(MontarCurriculo(dr));
			return lista;
		}


	}
}
