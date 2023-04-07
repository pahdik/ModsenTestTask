using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Library.BLL.DTO;
using Library.BLL.Services.Interfaces;
using System.Security.AccessControl;

namespace Library.WebApi.Controllers
{
    public class BookController: Controller
    {
        IBookService bookService;
        public BookController(IBookService bookServ) 
        {
           bookService= bookServ;
        }
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await bookService.GetAllBooks());
        }
        [HttpGet("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await bookService.GetBookById(id));
        }
        [HttpGet("GetByISBN")]
        [Authorize]
        public async Task<IActionResult> GetByISBN(string ISBN)
        {
            return Ok(await bookService.GetBookByISBN(ISBN));
        }
        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add(BookAddDTO model)
        {
            await bookService.AddBook(model);

            return Accepted();
        }
        [HttpPatch("Update")]
        [Authorize]
        public async Task<IActionResult> Update(BookUpdateDTO model)
        {
            await bookService.UpdateBook(model);

            return Accepted();
        }
        [HttpDelete("Delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await bookService.DeleteBook(id);
            return Accepted();    
        }

    }
}
