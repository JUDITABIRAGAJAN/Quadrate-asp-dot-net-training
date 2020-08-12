using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreGabi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStoreGabi.Pages.BookList
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.ID);
                BookFromDb.Name = Book.Name;
                BookFromDb.NoofCopy = Book.NoofCopy;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Edition = Book.Edition;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();


        }

    }
}