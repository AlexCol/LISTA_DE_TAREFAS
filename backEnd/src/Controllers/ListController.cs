using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.src.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ListController : ControllerBase {
  
}
