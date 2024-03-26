using System.Reflection;
using AutoMapper;

public class MappingProfile:Profile{

    public MappingProfile() 
    {
        ApplayMappingFromAssembly(Assembly.GetExecutingAssembly());
    }

    public void ApplayMappingFromAssembly(Assembly assembly){

        var lst = assembly.GetExportedTypes().Where(i=>i.GetInterfaces()
        .Any(t=>t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IMapForm<>))).ToList();

        foreach(var item in lst){
            var instance=Activator.CreateInstance(item);
            var method=item.GetMethod("Map")??item.GetInterface("IMapForm`1").GetMethod("Map");
            method?.Invoke(instance, new object[] {this});

        }
    }
}