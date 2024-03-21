using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste.Models;
using teste.Persistencia;

namespace teste.Controllers
{
	public class FuncionariosController : Controller
	{
		private FuncionarioPersist _persit;
		private GeneroPersist _genero;
		private DependentePersist _dependente;
		public FuncionariosController()
		{
			_persit = new FuncionarioPersist();
			_genero = new GeneroPersist();
			_dependente = new DependentePersist();
		}
		public IActionResult Index()
		{
			var lista = new List<Funcionario>();
			lista = _persit.Lista();			
			return View(lista);
		}
		public IActionResult IndexGenero(int id)
		{
			var lista = new List<Funcionario>();
			lista = _persit.Lista(DateTime.Parse("01/01/1980"), DateTime.Parse("31/12/2001"), id);
			return View(lista);
		}
		[HttpGet]
		public IActionResult Adicionar()
		{
			ViewData["Genero"] = new SelectList(_genero.Lista(), "ID", "NomeGenero");
			return View();
		}
		[HttpPost]
		public IActionResult Adicionar(Funcionario funcionario)
		{
			_persit.Add(funcionario);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult Atualizar(int id)
		{
			FuncionarioViewModel funcionario = new FuncionarioViewModel();
			funcionario.funcionario = _persit.GetId(id);
			funcionario.dependente = _dependente.Lista(id);
			return View(funcionario);
		}
		[HttpPost]
		public IActionResult Atualizar(FuncionarioViewModel funcionario)
		{
			_persit.Update(funcionario.funcionario);
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Deletar(int id)
		{
			_persit.Excluir(id);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult AdicionarDependente(int ID)
		{
			ViewData["Genero"] = new SelectList(_genero.Lista(), "ID", "NomeGenero");
			Dependente dependente = new Dependente();
			dependente.FuncionarioId = ID;
			return View(dependente);
		}
		[HttpPost]
		public IActionResult AdicionarDependente(Dependente dependente)
		{
			_dependente.Update(dependente);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public IActionResult AtualizarDependente(int ID)
		{
			ViewData["Genero"] = new SelectList(_genero.Lista(), "ID", "NomeGenero");
			Dependente dependente = new Dependente();
			dependente = _dependente.GetId(ID);
			return View(dependente);
		}
		[HttpPost]
		public IActionResult AtualizarDependente(Dependente dependente)
		{
			_dependente.Update(dependente);
			return RedirectToAction(nameof(Index));
		}
		public IActionResult DeletarDependente(int id)
		{
			_dependente.Excluir(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
