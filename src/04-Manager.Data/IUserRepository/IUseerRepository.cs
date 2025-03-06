namespace _04_Manager.Infrastructure.Repositories;

using _02_Manager.Domain.DTOs;
using _02_Manager.Domain.Entities;
using System.Collections.Generic;

public interface IUsuarioRepository
{
    User Add(User user);
    User ObterPorId(int id);
    IEnumerable<User> GetAll();
    void Update(User user);
    void Remover(int id);
}
