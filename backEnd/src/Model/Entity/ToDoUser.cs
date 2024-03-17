using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backEnd.src.Model.Entity;

[Table("to_do_user")]
public class ToDoUser : BaseEntity {
  [Column("nome")]
  public string Nome { get; set; }
  [Column("email")]
  public string Email { get; set; }
  [Column("deseja_lembrete")]
  public bool DesejaLembrete { get; set; }
}
