using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace backEnd.src.Model.HttpModels.Request;

public class ToDoListRequest {
  public Guid Id { get; set; }
  public string UserId { get; set; }
  public string Tarefa { get; set; }
  public bool Concluida { get; set; }
}
