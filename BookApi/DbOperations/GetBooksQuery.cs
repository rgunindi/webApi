using BookApi.DbContext;
using BookApi.Model;

namespace BookApi.DbOperations;

public class GetBooksQuery
{
    private readonly BookDbContext context;

    public GetBooksQuery(BookDbContext c)
    {
        context = c;
    }

    public IQueryable<BookView> Handle()
    {
        var b = context.BookStore.OrderBy(x => x.Id).Select(x => new BookView()
            {KitapIsmi = x.KitapIsmi, Yazar = x.Yazar});
        return b;
    }
}