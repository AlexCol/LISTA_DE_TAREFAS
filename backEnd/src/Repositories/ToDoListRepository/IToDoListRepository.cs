using backEnd.src.Model.Entity;
using backEnd.src.Repository.GenericRepository;

namespace backEnd.src.Repositories.ToDoListRepository;

public interface IToDoListRepository : IGenericRepository<ToDoList> {
  public List<ToDoList> SaveNewList(Guid userId, List<ToDoList> list);
  public List<ToDoList> FindeByUserId(Guid userId);
}
