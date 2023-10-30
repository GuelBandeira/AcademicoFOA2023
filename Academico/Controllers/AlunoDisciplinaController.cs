using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academico.Data;
using Academico.Models;

namespace Academico.Views
{
    public class AlunoDisciplinaController : Controller
    {
        private readonly AcademicoContext _context;

        public AlunoDisciplinaController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: AlunoDisciplina
        public async Task<IActionResult> Index()
        {
            var academicoContext = _context.AlunoDisciplina.Include(a => a.Aluno).Include(a => a.Disciplina);
            return View(await academicoContext.ToListAsync());
        }

        // GET: AlunoDisciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlunoDisciplina == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplina
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplina/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id");
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Id");
            return View();
        }

        // POST: AlunoDisciplina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,DisciplinaId,Ano,Semestre")] AlunoDisciplina alunoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Id", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplina/Edit/5
        public async Task<IActionResult> Edit(int? AlunoId, int? DisciplinaId,AlunoDisciplina alunoDisci)
        {
            if (_context.AlunoDisciplina == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplina.FindAsync(alunoDisci);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Id", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("AlunoId,DisciplinaId,Ano,Semestre")] AlunoDisciplina alunoDisciplina)
        {
            if (id != alunoDisciplina.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoDisciplinaExists(alunoDisciplina.AlunoId))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoDisciplina.AlunoId);
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Id", alunoDisciplina.DisciplinaId);
            return View(alunoDisciplina);
        }

        // GET: AlunoDisciplina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlunoDisciplina == null)
            {
                return NotFound();
            }

            var alunoDisciplina = await _context.AlunoDisciplina
                .Include(a => a.Aluno)
                .Include(a => a.Disciplina)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (alunoDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoDisciplina);
        }

        // POST: AlunoDisciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.AlunoDisciplina == null)
            {
                return Problem("Entity set 'AcademicoContext.AlunoDisciplina'  is null.");
            }
            var alunoDisciplina = await _context.AlunoDisciplina.FindAsync(id);
            if (alunoDisciplina != null)
            {
                _context.AlunoDisciplina.Remove(alunoDisciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoDisciplinaExists(int? id)
        {
            return (_context.AlunoDisciplina?.Any(e => e.AlunoId == id)).GetValueOrDefault();
        }
    }
}
