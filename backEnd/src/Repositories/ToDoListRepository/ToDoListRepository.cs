using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backEnd.src.Model.Context;
using backEnd.src.Model.Entity;
using backEnd.src.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace backEnd.src.Repositories.ToDoListRepository;

public class ToDoListRepository : GenericRepository<ToDoList>, IToDoListRepository {
  public ToDoListRepository(PostgreContext context) : base(context) {
    // _context é usado o do pai
  }

  public List<ToDoList> FindeByUserId(Guid userId) {
    return _context.ToDoLists.Include(tdl => tdl.User).Where(tdl => tdl.User.Id == userId).ToList();
  }

  public List<ToDoList> SaveNewList(Guid userId, List<ToDoList> list) {
    var user = _context.ToDoUsers.FirstOrDefault(u => u.Id == userId);
    if (user == null) throw new Exception("Usuário não encontrado!");

    DeleteFullList(userId);

    foreach (var item in list) {
      item.Id = Guid.Empty;
      item.User = user;
      _context.ToDoLists.Add(item);
    }

    _context.SaveChanges();
    return list;
  }

  private void DeleteFullList(Guid userId) {
    foreach (var item in FindeByUserId(userId)) {
      _context.ToDoLists.Remove(item);
    }
  }
}
