public static class BookModule
{

    public static void BooksEndPoints(this IEndpointRouteBuilder app)
    {

        var books = new List<Books>{
        new Books{Id=1,Title="MVC", Author="Microsoft"},
        new Books{Id=2,Title="React", Author="Facebook"},
    };

        app.MapGet("/book/{id}", (int id) =>
        {
            var book = books.Find(x => x.Id == id);
            if (book is null)
                return Results.NotFound("Book not found!");

            return Results.Ok(book);
        });

        app.MapPost("/AddBook", (Books entity) =>
        {
            books.Add(entity);
            return Results.Ok(books);
        });
    }
}