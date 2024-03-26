

using AutoMapper;
using Core.Models;

public partial class FournisseurDto:IMapForm<Fournisseur>
{
    public string Codefour { get; set; }

    public string Nom { get; set; }

    public string Tel { get; set; }

    public string Adresse { get; set; }

    public string Email { get; set; }

    public virtual ICollection<FouarticleDto> Fouarticles { get; set; } = new List<FouarticleDto>();

    public void Map(Profile profile)=>profile.CreateMap<Fournisseur,FournisseurDto>().ReverseMap();
}
