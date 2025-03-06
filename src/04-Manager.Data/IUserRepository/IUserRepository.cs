namespace _04_Manager.Data.Repository;

using _02_Manager.Domain.DTOs;
using _02_Manager.Domain.Entities;
using System.Collections.Generic;

public interface IUserRepository
{
    User Add(User user);
    User GetId(int id);
    IEnumerable<User> GetAll();
    void Update(User user);
    void Remover(int id);
}
