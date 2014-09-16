namespace BookStore.ConsoleClient
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using BookStore.Data;
    using BookStore.Models;

    public class XmlImporter
    {
        private BookstoreDBContext db;

        public XmlImporter(BookstoreDBContext db)
        {
            this.db = db;
        }

        public void ImportBooks(string path)
        {
            var xml = XElement.Load(path);
            var books = xml.XPathSelectElements("/book");

            foreach (var xmlBook in books)
            {
                var book = new Book();
                var title = xmlBook.XPathSelectElement("title").Value;

                book.Title = title;

                var authors = xmlBook.XPathSelectElements("authors/author");

                foreach (var xmlAuthor in authors)
                {
                    var authorExists = this.db.Authors.FirstOrDefault(x => x.Name == xmlAuthor.Value);
                    book.Authors.Add(authorExists ?? new Author() { Name = xmlAuthor.Value });
                }

                var webSite = xmlBook.XPathSelectElement("web-site");

                if (webSite != null)
                {
                    book.WebSite = webSite.Value;
                }

                var xmlReviews = xmlBook.XPathSelectElements("reviews/review");

                foreach (var xmlReview in xmlReviews)
                {
                    var review = new Review();
                    var revAuthor = xmlReview.Attribute("author");
                    if (revAuthor != null)
                    {
                        var authorExists = this.db.Authors.FirstOrDefault(x => x.Name == revAuthor.Value);

                        review.Author = authorExists ?? new Author() { Name = revAuthor.Value };
                    }

                    var revDate = xmlReview.Attribute("date");
                    review.DateCreated = revDate != null ? DateTime.Parse(revDate.Value) : DateTime.Now;

                    review.Content = xmlReview.Value;

                    book.Reviews.Add(review);
                }

                var xmlIsbn = xmlBook.XPathSelectElement("isbn");
                if (xmlIsbn != null)
                {
                    if (this.db.Books.Any(x => x.ISBN == xmlIsbn.Value))
                    {
                        throw new ArgumentException("A book with this ISBN already exists!");
                    }
                    book.ISBN = xmlIsbn.Value;
                }

                var xmlPrice = xmlBook.XPathSelectElement("price");

                if (xmlPrice != null)
                {
                    book.Price = decimal.Parse(xmlPrice.Value);
                }

                this.db.Books.Add(book);
                this.db.SaveChanges();
            }
        }

        public void PerformReviewQueries(string pathToImport, string pathToExport)
        {
            var queries = XElement.Load(pathToImport);

            var xmlResult = new XDocument();
            var xmlRoot = new XElement("search-results");
            xmlResult.Add(xmlRoot);

            foreach (var query in queries.XPathSelectElements("/query"))
            {
                var type = query.Attribute("type").Value;
                var set = new XElement("result-set");
                var result = this.db.Reviews.AsQueryable();
                if (type == "by-period")
                {
                    var startDate = DateTime.Parse(query.XPathSelectElement("start-date").Value);
                    var endDate = DateTime.Parse(query.XPathSelectElement("end-date").Value);

                    result = this.db.Reviews.Where(x => x.DateCreated >= startDate && x.DateCreated <= endDate);
                }
                if (type == "by-author")
                {
                    var authorName = query.XPathSelectElement("author-name").Value;

                    result = this.db.Reviews.Where(x => x.Author.Name == authorName);
                }

                var data =
                    result.Select(
                        x =>
                        new
                            {
                                Date = x.DateCreated,
                                Content = x.Content,
                                Book =
                            new
                                {
                                    Title = x.Book.Title,
                                    Authors = x.Book.Authors.OrderBy(y=>y.Name).Select(y=>y.Name),
                                    ISBN = x.Book.ISBN,
                                    Url = x.Book.WebSite
                                }
                            }).OrderBy(x => x.Date).ThenBy(x => x.Content).ToList();

                foreach (var review in data)
                {
                    var xmlReview = new XElement("review");
                    xmlReview.Add(new XElement("date", review.Date.ToString("d-MMM-yyyy")));
                    xmlReview.Add(new XElement("content", review.Content));

                    var xmlBook = new XElement("book");
                    var book = review.Book;
                    xmlBook.Add(new XElement("title", book.Title));
                    if (book.Authors.Any())
                    {
                        xmlBook.Add(
                            new XElement(
                                "authors",
                                string.Join(", ", book.Authors)));
                    }
                    if (book.ISBN != null)
                    {
                        xmlBook.Add(new XElement("isbn", book.ISBN));
                    }
                    if (book.Url != null)
                    {
                        xmlBook.Add(new XElement("url", book.Url));
                    }
                    xmlReview.Add(xmlBook);
                    set.Add(xmlReview);
                }

                xmlRoot.Add(set);
            }

            xmlResult.Save(pathToExport);
        }

        private void AddReviewResultSet(XElement element, IEnumerable results)
        {
        }
    }
}