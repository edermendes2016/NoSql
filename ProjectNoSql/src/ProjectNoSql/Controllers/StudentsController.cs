using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ProjectNoSql.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetStudent();
        }
        private async Task<string> GetStudent()
        {
            var student = await _studentRepository.Get();
            return JsonConvert.SerializeObject(student);
        }
        [HttpGet("{id}")]
        public Task<string> Get(string id)
        {
            return this.GetStudentById(id);
        }
        private async Task<string> GetStudentById(string id)
        {
            var students = await _studentRepository.Get(id) ?? new Student();
            return JsonConvert.SerializeObject(students);
        }
        [HttpPost]
        public async Task<string> Post([FromBody] Student student)
        {
            await _studentRepository.Add(student);
            return "";
        }
        [HttpPut("{id}")]
        public async Task<string> Put(string id, [FromBody] Student student)
        {
            if (id == null)
            {
                return "Invalid id!!!";
            }

            return await _studentRepository.Update(id, student);

        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (id == null)
            {
                return "Invalid id!!!";
            }
                
            await _studentRepository.Remove(id);
            return "";
        }
    }
}


