using System.Security.Claims;
using backEnd.src.Model.Entity;

namespace backEnd.src.Extensions.toClaims;

public static class ClaimsExtension {
  public static ToDoUser GetUser(this IEnumerable<Claim> claims) {
    var requestUserIdClaim = claims.FirstOrDefault(c => c.Type == "UserId");
    var requestUserNameClaim = claims.FirstOrDefault(c => c.Type == "UserName");
    var requestUserEMailClaim = claims.FirstOrDefault(c => c.Type == "UserEMail");
    if (requestUserIdClaim == null || requestUserNameClaim == null || requestUserEMailClaim == null) return null;

    return new ToDoUser {
      Id = Guid.Parse(requestUserIdClaim.Value),
      Nome = requestUserNameClaim.Value,
      Email = requestUserEMailClaim.Value
    };
  }
}
