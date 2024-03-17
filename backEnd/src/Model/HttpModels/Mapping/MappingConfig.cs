
using backEnd.src.Model.Entity;
using backEnd.src.Model.HttpModels.Request;

namespace backEnd.src.ValueObjects.Mapping;

public static class MappingConfig {
  public static AutoMapper.MapperConfiguration RegisterMaps() {
    var mappingCong = new AutoMapper.MapperConfiguration(config => {
      config.CreateMap<ToDoListRequest, ToDoList>()
        .ForMember(dest => dest.User, opt => opt.MapFrom(src => new ToDoUser { Id = src.Id }));

      config.CreateMap<ToDoList, ToDoListRequest>()
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));
    });
    return mappingCong;
  }
}