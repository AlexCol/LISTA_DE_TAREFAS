namespace nackEnd.src.Model.EmailModel;

public class EmailModel {
  public string smtpServer { get; set; }
  public int port { get; set; }
  public bool enableSSL { get; set; }
  public string emailFrom { get; set; }
  public string password { get; set; }
}