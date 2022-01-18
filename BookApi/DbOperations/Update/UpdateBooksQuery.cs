using BookApi.DbContext;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.DbOperations.Update;

public class UpdateBooksQuery
{
    private readonly BookDbContext context;
    
    public UpdateBooksQuery(BookDbContext c)
    {
        context = c;
    }

    public Boolean handle(int id,BookView updateBook)
    {
        var book = context.BookStore.SingleOrDefault(x => x.Id == id);
        if(book==null)return false;
        book!.Yazar = updateBook.Yazar;
        book.KitapIsmi = updateBook.KitapIsmi;
        context.SaveChanges();
        return true;
    }
}