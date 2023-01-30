using StudentCatalog.Models;
using MongoDB.Driver;

namespace StudentCatalog.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _students = database.GetCollection<Student>(settings.StudentCourseCollectionName);
        }
        public Student  Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }
        public List<Student> Get()
        {
            List<Student> response = _students.Find(student => true).ToList();
            return response;
        }

        public Student Get(string id)
        {
            Student response = _students.Find(student => student.Id == id).FirstOrDefault();
            return response;
        }
        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}
