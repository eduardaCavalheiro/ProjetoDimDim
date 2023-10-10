using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjDimDim.Data;
using ProjetoDimDim.Models;

namespace ProjetoDimDim.Controllers
{
    public class ImplantacoesController : Controller
    {
        private readonly ProjDimDimContext _context;

        public ImplantacoesController(ProjDimDimContext context)
        {
            _context = context;
        }

        // GET: Implantacoes
        public async Task<IActionResult> Index()
        {
            var projDimDimContext = _context.Implantacoes.Include(i => i.Projeto);
            return View(await projDimDimContext.ToListAsync());
        }

        // GET: Implantacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Implantacoes == null)
            {
                return NotFound();
            }

            var implantacao = await _context.Implantacoes
                .Include(i => i.Projeto)
                .FirstOrDefaultAsync(m => m.ImplantacaoId == id);
            if (implantacao == null)
            {
                return NotFound();
            }

            return View(implantacao);
        }

        // GET: Implantacoes/Create
        public IActionResult Create()
        {
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "ProjetoId", "ProjetoId");
            return View();
        }

        // POST: Implantacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImplantacaoId,StatusImplantacao,VersaoDocker,ServicoNuvem,ProjetoId")] Implantacao implantacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(implantacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "ProjetoId", "ProjetoId", implantacao.ProjetoId);
            return View(implantacao);
        }

        // GET: Implantacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Implantacoes == null)
            {
                return NotFound();
            }

            var implantacao = await _context.Implantacoes.FindAsync(id);
            if (implantacao == null)
            {
                return NotFound();
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "ProjetoId", "ProjetoId", implantacao.ProjetoId);
            return View(implantacao);
        }

        // POST: Implantacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImplantacaoId,StatusImplantacao,VersaoDocker,ServicoNuvem,ProjetoId")] Implantacao implantacao)
        {
            if (id != implantacao.ImplantacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(implantacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImplantacaoExists(implantacao.ImplantacaoId))
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
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "ProjetoId", "ProjetoId", implantacao.ProjetoId);
            return View(implantacao);
        }

        // GET: Implantacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Implantacoes == null)
            {
                return NotFound();
            }

            var implantacao = await _context.Implantacoes
                .Include(i => i.Projeto)
                .FirstOrDefaultAsync(m => m.ImplantacaoId == id);
            if (implantacao == null)
            {
                return NotFound();
            }

            return View(implantacao);
        }

        // POST: Implantacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Implantacoes == null)
            {
                return Problem("Entity set 'ProjDimDimContext.Implantacoes'  is null.");
            }
            var implantacao = await _context.Implantacoes.FindAsync(id);
            if (implantacao != null)
            {
                _context.Implantacoes.Remove(implantacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImplantacaoExists(int id)
        {
          return (_context.Implantacoes?.Any(e => e.ImplantacaoId == id)).GetValueOrDefault();
        }
    }
}
