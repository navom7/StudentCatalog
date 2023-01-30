using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace StudentCatalog.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("graduated")]
        public bool IsGraduated { get; set; }
        [BsonElement("address")]
        public Address Address { get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
    }

}
