using System.Collections.Generic;

namespace ProjectManagement.Common.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T value);

        List<T> RetrieveAll();

        T RetrieveByID(int ID);

        T Update(T value);

        bool Delete(int ID);
    }
}