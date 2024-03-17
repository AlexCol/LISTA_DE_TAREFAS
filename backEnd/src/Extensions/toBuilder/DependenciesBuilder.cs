using backEnd.src.Repository.GenericRepository;
using backEnd.src.Services.CryptoService;
using backEnd.src.Services.UserService;

namespace backEnd.src.Extensions.toBuilder;

public static class DependenciesBuilder {
  public static void addDependencies(this WebApplicationBuilder builder, IConfiguration _config) {
    //!adicionando configurações padrão
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddControllers();

    //!adicionando configurações
    builder.addPostgre();
    builder.AddCors(); //?lembrar depois de colocar useCors no app
    builder.addLogService();
    builder.addJWTService(_config);


    //!adicionando classes para injeções de dependencia
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddScoped<ICryptoService, CryptoService>();
    builder.Services.AddScoped<IUserService, UserService>();
  }
}
