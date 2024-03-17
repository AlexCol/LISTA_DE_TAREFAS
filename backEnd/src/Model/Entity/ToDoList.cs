using System.ComponentModel.DataAnnotations.Schema;

namespace backEnd.src.Model.Entity;

[Table("to_do_list")]
public class ToDoList : BaseEntity {
  public int MyProperty { get; set; }
  public ToDoUser User { get; set; }
  [Column("tarefa")]
  public string Tarefa { get; set; }
  [Column("concluida")]
  public bool Concluida { get; set; }
}
