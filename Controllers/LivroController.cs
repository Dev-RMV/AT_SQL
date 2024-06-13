using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AT_SQL.Data;
using AT_SQL.Models;

namespace AT_SQL.Controllers
{
    public class LivroController : Controller
    {
        private readonly AT_SQLContext _context;

        public LivroController(AT_SQLContext context)
        {
            _context = context;
        }

        // GET: Livro
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livro.ToListAsync());
        }
        */
        //do impacta
        public async Task<IActionResult> Index(string? procuraLivro)
        {
            //if(procuraLivro == null) procuraLivro = string.Empty;
            if (_context.Livro == null || procuraLivro == null)
            {
                return _context.Livro != null ?
                         //View(await _context.Livro.ToListAsync()) :
                         View():
                         Problem("Entidade Livro is null.");
            }
            //LINQ adicionado 
            var livros = from livro in _context.Livro select livro;
            if (procuraLivro.Trim()!= "")
            {
                livros = livros.Where(s => s.NomeLivro.ToString().ToLower().Contains(procuraLivro.ToString().ToLower()));
                return View(await livros.ToListAsync());
            }

            return View(await _context.Livro.ToListAsync());
        }
        //fim do impacta












        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Capa,NomeLivro,NomeUsuario,EmailUsuario,Resenha")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Capa,NomeLivro,NomeUsuario,EmailUsuario,Resenha")] Livro livro)
        {
            if (id != livro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.ID))
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
            return View(livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.ID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.ID == id);
        }
    }
}
