using BookApi.DbContext;
using BookApi.Model;

namespace BookApi.DbOperations;

public class GetByIdBookQuery
{
    private readonly BookDbContext context;

    public GetByIdBookQuery(BookDbContext c)
    {
        context = c;
    }

    public IQueryable<BookView> Handle(int id)
    {
        var b = context.BookStore.Where(x => x.Id==id).Select(x => new BookView()
            {KitapIsmi = x.KitapIsmi, Yazar = x.Yazar});
        return b;
    }
}