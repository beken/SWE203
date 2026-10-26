using LibraryManagement.Models;

namespace LibraryManagement.Data;

public static class SeedData
{
    public static void Initialize(LibraryContext context)
    {
        if (context.Books.Any()) return;

        // Genres
        var dystopia   = new Genre { Name = "Dystopia" };
        var fantasy    = new Genre { Name = "Fantasy" };
        var comedy     = new Genre { Name = "Comedy" };
        var romance    = new Genre { Name = "Romance" };
        var novel      = new Genre { Name = "Novel" };
        var shortStory = new Genre { Name = "Short Story" };
        var classic    = new Genre { Name = "Classic" };

        // Authors
        var orwell    = new Author { FullName = "George Orwell" };
        var huxley    = new Author { FullName = "Aldous Huxley" };
        var gaiman    = new Author { FullName = "Neil Gaiman" };
        var pratchett = new Author { FullName = "Terry Pratchett" };
        var tolkien   = new Author { FullName = "J.R.R. Tolkien" };
        var austen    = new Author { FullName = "Jane Austen" };
        var tanpinar  = new Author { FullName = "Ahmet Hamdi Tanpınar" };
        var guntekin  = new Author { FullName = "Reşat Nuri Güntekin" };
        var usakligil = new Author { FullName = "Halit Ziya Uşaklıgil" };
        var saitFaik  = new Author { FullName = "Sait Faik Abasıyanık" };
        var atwood    = new Author { FullName = "Margaret Atwood" }; // no books

        // Books
        var b1984      = new Book { Title = "1984", ISBN = "9780000000011", PublicationYear = 1949, TotalCopies = 1, Author = orwell, Genres = { dystopia, classic } };
        var animalFarm = new Book { Title = "Animal Farm", ISBN = "9780000000028", PublicationYear = 1945, TotalCopies = 2, Author = orwell, Genres = { dystopia, classic } };
        var brave      = new Book { Title = "Brave New World", ISBN = "9780000000035", PublicationYear = 1932, TotalCopies = 2, Author = huxley, Genres = { dystopia } };
        var omens      = new Book { Title = "Good Omens", ISBN = "9780000000042", PublicationYear = 1990, TotalCopies = 2, Author = gaiman, Genres = { fantasy, comedy } };
        var neverwhere = new Book { Title = "Neverwhere", ISBN = "9780000000059", PublicationYear = 1996, TotalCopies = 1, Author = gaiman, Genres = { fantasy } };
        var colour     = new Book { Title = "The Colour of Magic", ISBN = "9780000000141", PublicationYear = 1983, TotalCopies = 2, Author = pratchett, Genres = { fantasy, comedy } };
        var hobbit     = new Book { Title = "The Hobbit", ISBN = "9780000000066", PublicationYear = 1937, TotalCopies = 4, Author = tolkien, Genres = { fantasy, classic } };
        var silmarill  = new Book { Title = "The Silmarillion", ISBN = "9780000000073", PublicationYear = 1977, TotalCopies = 1, Author = tolkien, Genres = { fantasy } };
        var pride      = new Book { Title = "Pride and Prejudice", ISBN = "9780000000080", PublicationYear = 1813, TotalCopies = 2, Author = austen, Genres = { romance, classic } };
        var calikusu   = new Book { Title = "Çalıkuşu", ISBN = "9780000000097", PublicationYear = 1922, TotalCopies = 1, Author = guntekin, Genres = { novel, romance } };
        var huzur      = new Book { Title = "Huzur", ISBN = "9780000000103", PublicationYear = 1949, TotalCopies = 2, Author = tanpinar, Genres = { novel } };
        var saatleri   = new Book { Title = "Saatleri Ayarlama Enstitüsü", ISBN = "9780000000110", PublicationYear = 1961, TotalCopies = 2, Author = tanpinar, Genres = { novel, comedy } };
        var askiMemnu  = new Book { Title = "Aşk-ı Memnu", ISBN = "9780000000127", PublicationYear = 1900, TotalCopies = 1, Author = usakligil, Genres = { novel, classic } };
        var semaver    = new Book { Title = "Semaver", ISBN = "9780000000011", PublicationYear = 1936, TotalCopies = 2, Author = saitFaik, Genres = { shortStory } };

        context.Authors.Add(atwood);
        context.Genres.AddRange(dystopia, fantasy, comedy, romance, novel, shortStory, classic);
        context.Books.AddRange(b1984, animalFarm, brave, omens, neverwhere, colour, hobbit, silmarill,
                               pride, calikusu, huzur, saatleri, askiMemnu, semaver);

        // Borrowings: (book, borrower, borrowed X days ago, returned Y days ago or null)
        var today = DateTime.Today;
        Borrowing B(Book book, string name, int borrowedAgo, int? returnedAgo) => new Borrowing
        {
            Book = book,
            BorrowerName = name,
            BorrowDate = today.AddDays(-borrowedAgo),
            DueDate = today.AddDays(-borrowedAgo + 14),
            ReturnDate = returnedAgo == null ? null : today.AddDays(-returnedAgo.Value)
        };

        context.Borrowings.AddRange(
            B(hobbit, "Ali", 120, 110), B(hobbit, "Ayşe", 100, 90), B(hobbit, "Mehmet", 80, 70),
            B(hobbit, "Zeynep", 60, 50), B(hobbit, "Can", 40, 30), B(hobbit, "Elif", 5, null),

            B(b1984, "Ali", 90, 80), B(b1984, "Burak", 70, 60), B(b1984, "Deniz", 50, 40),
            B(b1984, "Ayşe", 20, null), B(b1984, "Can", 3, null),

            B(omens, "Zeynep", 95, 85), B(omens, "Deniz", 75, 60), B(omens, "Elif", 45, 35),
            B(omens, "Mehmet", 3, null),

            B(brave, "Burak", 85, 75), B(brave, "Can", 65, 55), B(brave, "Elif", 30, null),

            B(pride, "Ayşe", 110, 100), B(pride, "Deniz", 55, 45), B(pride, "Zeynep", 35, 25),

            B(calikusu, "Mehmet", 70, 58), B(calikusu, "Zeynep", 25, null),

            B(neverwhere, "Ali", 60, 48), B(neverwhere, "Burak", 10, null),

            B(huzur, "Can", 50, 40),
            B(askiMemnu, "Deniz", 40, 30),
            B(semaver, "Burak", 20, 12)
        );

        context.SaveChanges();
    }
}