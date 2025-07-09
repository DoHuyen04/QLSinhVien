using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSinhVien.Models;

namespace WebSinhVien.Controllers
{
    public class KetQuasController : Controller
    {
        private readonly AppDataContext _context;

        public KetQuasController(AppDataContext context)
        {
            _context = context;
        }
        public IActionResult SearchDiemToan()
        {
            var result = _context.KetQua
                .Where(kq => kq.monhoc == "Toán" && kq.diem > 8)
                .Include(kq => kq.SinhVien)
                
                .Distinct()
                .ToList();

            return View(result);
        }
        // GET: KetQuas
        public async Task<IActionResult> Index()
        {
            return View(await _context.KetQua.ToListAsync());
        }

        // GET: KetQuas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQua
                .FirstOrDefaultAsync(m => m.makq == id);
            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // GET: KetQuas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KetQuas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("makq,masv,monhoc,diem")] KetQua ketQua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ketQua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ketQua);
        }

        // GET: KetQuas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQua.FindAsync(id);
            if (ketQua == null)
            {
                return NotFound();
            }
            return View(ketQua);
        }

        // POST: KetQuas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("makq,masv,monhoc,diem")] KetQua ketQua)
        {
            if (id != ketQua.makq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ketQua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KetQuaExists(ketQua.makq))
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
            return View(ketQua);
        }

        // GET: KetQuas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ketQua = await _context.KetQua
                .FirstOrDefaultAsync(m => m.makq == id);
            if (ketQua == null)
            {
                return NotFound();
            }

            return View(ketQua);
        }

        // POST: KetQuas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ketQua = await _context.KetQua.FindAsync(id);
            if (ketQua != null)
            {
                _context.KetQua.Remove(ketQua);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KetQuaExists(int id)
        {
            return _context.KetQua.Any(e => e.makq == id);
        }
    }
}
