using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Models;
using System.Diagnostics;
using System.Security.Policy;
using System.Text;

namespace PL.Controllers
{
    public class FolderController : Controller
    {
        private readonly FolderDBContext _dbContext;

        public FolderController(FolderDBContext context)
        {
            _dbContext = context;
        }
        public async Task<IActionResult> Index(string name)
        {
            string title = name ?? "Root";
            ViewBag.Name = title;
            ViewData["Title"] = title;

            if (name == null)
            {
                return View(await _dbContext.Folders.Where(c => c.ParentId == null).ToListAsync());
            }

            var id = await _dbContext.Folders.Where(f => f.Name.Equals(name)).Select(f => f.Id).FirstOrDefaultAsync();
            return View(await _dbContext.Folders.Where(c => c.ParentId == id).ToListAsync());
        }
    }
}