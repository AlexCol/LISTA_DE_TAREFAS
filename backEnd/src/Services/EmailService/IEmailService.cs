namespace backEnd.src.Services.EmailService;

public interface IEmailService {
  void sendRegisterEmail(string email, string origin);
  void sendRecoverPasswordEmail(string email, string origin);
}
