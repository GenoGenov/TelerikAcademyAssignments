using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ConsoleClient
{
    using System.Data.Entity;
    using System.Globalization;
    using System.Threading;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using BookStore.Data;
    using BookStore.Data.Migrations;
    using BookStore.Models;

    class Program
    {
       

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var db = new BookstoreDBContext("Bookstore");
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookstoreDBContext, Configuration>());
            var importer = new XmlImporter(db);
            //importer.ImportBooks("..//..//..//complex-books.xml");
            importer.PerformReviewQueries("..//..//..//reviews-queries.xml", "..//..//..//reviews-search-results.xml");
        }


    }
}
