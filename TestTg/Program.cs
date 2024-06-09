using Microsoft.EntityFrameworkCore;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Domain.ValueObjects;
using TelegramBotPractice.Infrastructure.Context;

var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

//var g1 = new Genre { Name = "Фантастика", Description = "Книги о фантастических мирах и событиях" };
//var g2 = new Genre { Name = "Детектив", Description = "Книги с загадками и расследованиями преступлений" };
//var g3 = new Genre { Name = "Роман", Description = "Книги о любви и отношениях" };
//var g4 = new Genre { Name = "Приключения", Description = "Книги с захватывающими приключениями главных героев" };
//var g5 = new Genre { Name = "Фэнтези", Description = "Книги о магии, волшебных существах и мирах" };
//var g6 = new Genre { Name = "Драма", Description = "Литературный жанр, в котором рассматриваются различные стороны человеческой жизни" };
//var listGenres = new List<Genre>();
//listGenres.Add(g1);
//listGenres.Add(g2);
//listGenres.Add(g3);
//listGenres.Add(g4);
//listGenres.Add(g5);
//listGenres.Add(g6);

//db.Genres.AddRange(listGenres);
//await db.SaveChangesAsync();

//var a1 = new Author { FullName = new FullName(firstName: "Александр", lastName: "Пушкин", middleName: "Сергеевич" ) };
//var a2 = new Author { FullName = new FullName(firstName: "Лев", lastName: "Толстой",  middleName: "Николаевич" ) };
//var a3 = new Author { FullName = new FullName(firstName: "Федор", lastName: "Достоевский",  middleName: "Михайлович" ) };
//var a4 = new Author { FullName = new FullName(firstName: "Михаил", lastName: "Булгаков",  middleName: null ) };
//var a5 = new Author { FullName = new FullName(firstName: "Антон", lastName: "Чехов",  middleName: "Павлович" ) };

//var authors = new List<Author>();
//authors.Add(a1);
//authors.Add(a2);
//authors.Add(a3);
//authors.Add(a4);
//authors.Add(a5);

//db.Authors.AddRange(authors);
//await db.SaveChangesAsync();

// Добавление книг \Если бы я не был ебланом 
/*var books = new List<Book>
{
    new Book
    {
        Name = "Евгений Онегин",
        Description = "Роман в стихах",
        YearOfIssue = new DateTime(1833, 1, 1),
        AuthorId = a1.Id
    },
    new Book
    {
        Name = "Война и мир",
        Description = "Роман-эпопея",
        YearOfIssue = new DateTime(1869, 1, 1),
        AuthorId = a2.Id 
    },
    new Book
    {
        Name = "Преступление и наказание",
        Description = "Роман",
        YearOfIssue = new DateTime(1866, 1, 1),
        AuthorId = a3.Id
    },
    new Book
    {
        Name = "Мастер и Маргарита",
        Description = "Роман",
        YearOfIssue = new DateTime(1967, 1, 1),
        AuthorId = a4.Id
    },
    new Book
    {
        Name = "Три сестры",
        Description = "Пьеса",
        YearOfIssue = new DateTime(1900, 1, 1),
        AuthorId = a5.Id
    }
};

db.Books.AddRange(books);
await db.SaveChangesAsync();*/

//var existingAuthors = db.Authors.ToList();
//var b1 = new Book
//{
//    Name = "Преступление и наказание",
//    Description = "Драма",
//    YearOfIssue = new DateTime(1866, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Установите Kind в Utc
//    AuthorId = existingAuthors.FirstOrDefault(a => a.FullName.FirstName == "Федор" && a.FullName.LastName == "Достоевский")?.Id ?? Guid.Empty
//};
//var b2 = new Book
//{
//    Name = "Мастер и Маргарита",
//    Description = "Роман, Фэнтези",
//    YearOfIssue = new DateTime(1967, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Установите Kind в Utc
//    AuthorId = existingAuthors.FirstOrDefault(a => a.FullName.FirstName == "Михаил" && a.FullName.LastName == "Булгаков")?.Id ?? Guid.Empty
//};
//var b3 = new Book
//{
//    Name = "Три сестры",
//    Description = "Пьеса",
//    YearOfIssue = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc), // Установите Kind в Utc
//    AuthorId = existingAuthors.FirstOrDefault(a => a.FullName.FirstName == "Антон" && a.FullName.LastName == "Чехов")?.Id ?? Guid.Empty
//};
//var newBooks = new List<Book> { b1, b2, b3 };
//db.Books.AddRange(newBooks);
//await db.SaveChangesAsync();

//var existingGenres = db.Genres.ToList();
//var existingBooks = db.Books.ToList();

//var bookGenreMappings = new List<BookOfGenre>();
//foreach (var book in existingBooks)
//{
//    var genreIds = new List<Guid>();

//    if (book.Name == "Преступление и наказание")
//    {
//        genreIds.Add(existingGenres.First(g => g.Name == "Драма").Id);
//    }
//    else if (book.Name == "Мастер и Маргарита")
//    {
//        genreIds.Add(existingGenres.First(g => g.Name == "Роман").Id);
//        genreIds.Add(existingGenres.First(g => g.Name == "Фэнтези").Id);
//    }
//    else if (book.Name == "Три сестры")
//    {
//        genreIds.Add(existingGenres.First(g => g.Name == "Драма").Id);
//    }

//    foreach (var genreId in genreIds)
//    {
//        bookGenreMappings.Add(new BookOfGenre { BookId = book.Id, GenreId = genreId });
//    }
//}

//db.BookOfGenres.AddRange(bookGenreMappings);
//await db.SaveChangesAsync();