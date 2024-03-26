using AutoMapper;

public interface IMapForm<T>{
    void Map(Profile profile)=>profile.CreateMap(typeof(T),GetType());
}