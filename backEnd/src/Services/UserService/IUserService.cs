using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.src.Model.Entity;

namespace backEnd.src.Services.UserService;

public interface IUserService {
  public ToDoUser FindById(Guid id);
  public ToDoUser Create(ToDoUser user);
  public ToDoUser Update(ToDoUser user);
  public ToDoUser UpdateNameAndEmail(ToDoUser user);
  public void Delete(Guid id);
}
