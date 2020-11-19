using System;
using System.Collections.Generic;


public interface IRepository<T>: IDisposable
{
    void Add(T student);
    void Update(T student);
    void Remove(Guid id);
    T FindById(Guid id);
    IEnumerable<T> FindAll();
}

