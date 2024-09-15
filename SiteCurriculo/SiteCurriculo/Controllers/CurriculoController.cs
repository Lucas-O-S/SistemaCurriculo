using Microsoft.AspNetCore.Mvc;
using SiteCurriculo.DAO;
using SiteCurriculo.Models;

namespace SiteCurriculo.Controllers
{
	public class CurriculoController : Controller
	{
		public IActionResult Index()
		{
			try
			{
				CurriculoDAO dao = new CurriculoDAO();
				List<CurriculoViewModel> lista = dao.Listagem();
				return View(lista);
			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}

		}

		public IActionResult Create()
		{

			CurriculoViewModel curriculo = new CurriculoViewModel();
			return View("Form",curriculo);

		}

		public IActionResult Salvar(CurriculoViewModel curriculo)
		{
			try
			{
				CurriculoDAO dao = new CurriculoDAO();
				if (dao.Consulta(curriculo.cpf) == null)
					dao.Inserir(curriculo);
				else
					dao.Alterar(curriculo);




			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
			return RedirectToAction("index");
		}

		public IActionResult Edit(string cpf)
		{
			try
			{
				CurriculoDAO dao = new CurriculoDAO();
				CurriculoViewModel curriculo = dao.Consulta(cpf);
				if (curriculo == null)
				{
					return RedirectToAction("Index");
				}
				else
				{
					return View("Form", curriculo);
				}
			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
		}

		public IActionResult Delete(string cpf)
		{
			try
			{
				CurriculoDAO dao = new CurriculoDAO();
				dao.Excluir(cpf);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
		}
	}
}
