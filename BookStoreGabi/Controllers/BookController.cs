using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreGabi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookStoreGabi.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }




        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        
        }


        public async Task<IActionResult>Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.ID == id);
            if(bookFromDb== null)
            {
                return Json(new { success = false, Message = "Error while Deleting" });
            }
            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, Message = "Delete successful" });
        }

           
    }
}
