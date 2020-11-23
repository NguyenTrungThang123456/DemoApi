using System;
namespace DemoApi.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository Students { get; }
        int Complete();
    }
}
