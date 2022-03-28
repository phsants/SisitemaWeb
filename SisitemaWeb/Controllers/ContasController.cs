using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisitemaWeb.Models;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class ContasController : Controller
    {
        private readonly Contexto _context;

        public ContasController(Contexto context)
        {
            _context = context;
        }

        // GET: Contas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Conta.Include(c => c.Classificacao).Include(c => c.Tipo);
            return View(await contexto.ToListAsync());
        }

        // GET: Contas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Descricao");
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Metodospagamento");
            return View();
        }

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,descricao,Valor,DataPagamento,DataVencimento,TipoId,ClassificacaoId")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Descricao", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Metodospagamento", conta.TipoId);
            return View(conta);
        }

        // GET: Contas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Descricao", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Metodospagamento", conta.TipoId);
            return View(conta);
        }

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,descricao,Valor,DataPagamento,DataVencimento,TipoId,ClassificacaoId")] Conta conta)
        {
            if (id != conta.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaExists(conta.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacaoId"] = new SelectList(_context.Classificacao, "Id", "Descricao", conta.ClassificacaoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Metodospagamento", conta.TipoId);
            return View(conta);
        }

        // GET: Contas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conta = await _context.Conta
                .Include(c => c.Classificacao)
                .Include(c => c.Tipo)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (conta == null)
            {
                return NotFound();
            }

            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conta = await _context.Conta.FindAsync(id);
            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaExists(int id)
        {
            return _context.Conta.Any(e => e.ItemId == id);
        }
    }
}
