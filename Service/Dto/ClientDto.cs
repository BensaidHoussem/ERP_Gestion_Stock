using AutoMapper;
using Core.Models;

public partial class ClientDto:IMapForm<Client>
{
    public string Codeclient { get; set; }

    public string Nom { get; set; }

    public string Adresse { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public virtual ICollection<CommandeDto> Commandes { get; set; } = new List<CommandeDto>();

    public void Map(Profile profile)=>profile.CreateMap<Client,ClientDto>().ReverseMap();
}