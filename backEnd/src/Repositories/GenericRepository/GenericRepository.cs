using backEnd.src.Model.Context;
using backEnd.src.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace backEnd.src.Repository.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
  protected readonly PostgreContext _context;
  private DbSet<T> dataset;

  public GenericRepository(PostgreContext context) {
    _context = context;
    dataset = context.Set<T>();
  }

  virtual public T FindById(Guid id) {
    T item = dataset.SingleOrDefault(p => p.Id.Equals(id));
    return item;
  }

  virtual public List<T> FindAll() {
    return dataset.ToList();
  }

  virtual public T Create(T item) {
    try {
      dataset.Add(item);
      _context.SaveChanges();
      return item;
    } catch (Exception e) {
      throw new InvalidDataException("Erro ao cadastrar. " + e.Message);
    }
  }

  virtual public T Update(T item) {
    T itemAtual = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
    if (itemAtual == null) throw new InvalidDataException("Erro ao atualizar o registro.");

    _context.Entry(itemAtual).CurrentValues.SetValues(item);
    _context.SaveChanges();
    return item;
  }
  virtual public void Delete(Guid id) {
    var user = FindById(id);
    if (user == null) throw new Exception("Item não encontrado ou já excluído.");

    dataset.Remove(user);
    _context.SaveChanges();
  }
}
