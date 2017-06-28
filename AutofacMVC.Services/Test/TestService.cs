using Cp.Core.Data;
using Cp.Core.Domain.TestModels;

namespace CpMVC.Services.Test
{
    public class TestService:ITestService
    {
        private readonly IRepository<Student> _studentRepository;

        public TestService(IRepository<Student> studentRepository )
        {
            _studentRepository = studentRepository;
        }


        public void InsertStudent(Student student)
        {
            _studentRepository.Insert(student);
        }
    }
}