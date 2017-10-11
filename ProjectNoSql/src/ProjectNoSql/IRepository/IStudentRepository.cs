using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectNoSql.Controllers
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> Get(string id);
        Task Add(Student Student);
        Task<string> Update(string id, Student Student);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();

    }
}
