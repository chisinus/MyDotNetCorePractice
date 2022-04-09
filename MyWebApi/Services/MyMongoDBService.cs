using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyWebApi.Models;

namespace MyWebApi.Services
{
    /* Prepare data
        db.Books.insertOne({ "Name": "Design Patterns", "Price": 54.93, "Category": "Computers", "Author": "Ralph Johnson", "PublishDate" :   ISODate("2020-01-01T00:00:00Z")})

        db.Books.insertMany([{ "Name": "Clean Code", "Price": 43.15, "Category": "Computers", "Author": "Robert C. Martin", "PublishDate" :  ISODate("2020-01-02T00:00:00Z")}])


        Insert Body:

            {
            "BookName": "Book1",
            "Price": 1,
            "Category": "Misc",
            "Author": "Jun Xia",
            "PublishDate": "2022-04-09T20:10:47.865Z"
        }    
    */
    public class MyMongoDBService : IMyMongoDBService
    {
        private readonly IMongoCollection<Book> _booksCollection;

        public MyMongoDBService(IOptions<MyMongoDBSettings> myMongoDBSettings)
        {
            var mongoClient = new MongoClient(myMongoDBSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(myMongoDBSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(myMongoDBSettings.Value.BooksCollectionName);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _booksCollection.FindAsync(_ => true).Result.ToListAsync();
        }

        public async Task<Book> GetBook(string id)
        {
            return await _booksCollection.FindAsync(b => b.Id == id).Result.FirstOrDefaultAsync();
        }

        public async Task<string> InsertBook(string bookName, decimal price, string category, string author, DateTime publishDate)
        {
            Book newBook = new Book { BookName = bookName, Price = price, Category = category, Author = author, PublishDate = publishDate };
            await _booksCollection.InsertOneAsync(newBook);
            
            return newBook.Id;
        }   

        public async Task<UpdateResult> UpdateBookName(string id, string bookName)
        {
            // replace whole document
            //Book book = GetBook(id).Result;
            //if (book == null) return;

            //book.BookName = bookName;

            //// replace replace whole document

            // update field/fields
            var filter = Builders<Book>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Book>.Update.Set(b=>b.BookName, bookName);
            
            return await _booksCollection.UpdateOneAsync(filter, update);
        }

        public async Task<DeleteResult> DeleteBook(string id)
        {
            var filter = Builders<Book>.Filter.Eq("_id", ObjectId.Parse(id));
            return await _booksCollection.DeleteOneAsync(filter);
        }
    }
}
