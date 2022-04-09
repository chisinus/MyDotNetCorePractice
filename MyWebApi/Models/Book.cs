using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyWebApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string BookName { get; set; } = "";
        
        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; } = "";
        
        [BsonElement("Author")]
        public string Author { get; set; } = "";

        // alway receives converting error
        //[BsonElement("PublishDate")]
        //[BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.String)]
        //public DateTime PublishDate { get; set; }
        public string PublishDate { get; set; }
    }
}
