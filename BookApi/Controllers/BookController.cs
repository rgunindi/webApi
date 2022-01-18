using BookApi.DbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BookApi.DbOperations;
using BookApi.DbOperations.Update;
using BookApi.Model;

namespace BookApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookDbContext context;

    public BookController( BookDbContext c)
    {
        context = c;
    }
    [HttpGet]
    public IActionResult GetBooks()
    {
        // var b = context.BookStore.OrderBy(x => x.Id).Select(x => new BookView()
        //     {KitapIsmi = x.KitapIsmi, Yazar = x.Yazar});
        GetBooksQuery b = new GetBooksQuery(context);
        var result=b.Handle();
        return Ok(result);
    } 
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // var b = context.BookStore.Where(x => x.Id==id).Select(x => new BookView()
        //     {KitapIsmi = x.KitapIsmi, Yazar = x.Yazar});
        GetByIdBookQuery b= new GetByIdBookQuery(context);
        var result = b.Handle(id);
        return Ok(result);
    }
        
    [HttpPost]
    public IActionResult Post(string yazar,string kitapismi)
    {
        context.Add(new Book(){KitapIsmi = kitapismi,Yazar = yazar});
        context.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(int id,[FromBody] BookView updateBook)
    {
        // var book = context.BookStore.SingleOrDefault(x => x.Id == id);
        // book!.Yazar = updateBook.Yazar;
        // book.KitapIsmi = updateBook.KitapIsmi;
        // context.SaveChanges();
        UpdateBooksQuery u = new UpdateBooksQuery(context);
        var result=u.handle(id, updateBook);
        if (result)
            return Ok();
        
        return BadRequest();
    }
}