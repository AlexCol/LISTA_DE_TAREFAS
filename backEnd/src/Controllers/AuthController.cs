using backEnd.src.Extensions.toClaims;
using backEnd.src.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backEnd.src.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class AuthController : ControllerBase {

  private readonly IUserService _service;
  public AuthController(IUserService service) {
    _service = service;
  }

  [HttpPost]
  public IActionResult Auth() {
    var userData = User.Claims.GetUser();

    var baseUser = _service.FindById(userData.Id);
    if (baseUser == null) {
      _service.Create(userData);
    } else {
      _service.UpdateNameAndEmail(userData);
    }

    return Ok();
  }
}