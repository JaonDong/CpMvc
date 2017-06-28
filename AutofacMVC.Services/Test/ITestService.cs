using Cp.Core.Domain.TestModels;

namespace CpMVC.Services.Test
{
    public interface ITestService:IBaseService
    {
        void InsertStudent(Student student);
    }
}