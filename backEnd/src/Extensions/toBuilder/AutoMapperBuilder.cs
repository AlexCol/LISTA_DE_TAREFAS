using AutoMapper;
using backEnd.src.ValueObjects.Mapping;

namespace backEnd.src.Extensions.toBuilder;

public static class AutoMapperBuilder {
  public static void AddAutoMapper(this WebApplicationBuilder builder) {
    //!configuração do automapping (pra evitar precisar criar um conversor)
    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    builder.Services.AddSingleton(mapper);
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
  }

}
