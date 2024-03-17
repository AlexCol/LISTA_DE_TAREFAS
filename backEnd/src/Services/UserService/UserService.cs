using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.src.Model.Entity;
using backEnd.src.Repository.GenericRepository;

namespace backEnd.src.Services.UserService;

public class UserService : IUserService {

  private readonly IGenericRepository<ToDoUser> _repo;
  public UserService(IGenericRepository<ToDoUser> repo) {
    _repo = repo;
  }

  public ToDoUser FindById(Guid id) {
    return _repo.FindById(id);
  }

  public ToDoUser Create(ToDoUser user) {
    return _repo.Create(user);
  }

  public ToDoUser Update(ToDoUser user) {
    var baseUser = FindById(user.Id);
    if (baseUser == null) throw new Exception("Usuario não encontrado!");
    baseUser.Nome = baseUser.Nome != user.Nome ? user.Nome : baseUser.Nome;
    baseUser.Email = baseUser.Email != user.Email ? user.Email : baseUser.Email;
    baseUser.DesejaLembrete = user.DesejaLembrete;
    return _repo.Update(baseUser);
  }

  public ToDoUser UpdateNameAndEmail(ToDoUser user) {
    var baseUser = FindById(user.Id);
    if (baseUser == null) throw new Exception("Usuario não encontrado!");
    baseUser.Nome = baseUser.Nome != user.Nome ? user.Nome : baseUser.Nome;
    baseUser.Email = baseUser.Email != user.Email ? user.Email : baseUser.Email;
    return _repo.Update(baseUser);
  }

  public void Delete(Guid id) {
    var baseUser = FindById(id);
    if (baseUser == null) throw new Exception("Usuario não encontrado!");
    _repo.Delete(id);
  }
}
