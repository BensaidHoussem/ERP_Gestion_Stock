using AutoMapper;
using Core.Models;

public partial class CommandeDto:IMapForm<Commande>
{
    public string Numcmd { get; set; }

    public string Codeclient { get; set; }

    public DateOnly? Datecmd { get; set; }

    public decimal? Prix { get; set; }

    public decimal? Tva { get; set; }

    public decimal? Prixttc { get; set; }

    public virtual ClientDto CodeclientNavigation { get; set; }

    public virtual ICollection<ListarticleDto> Listarticles { get; set; } = new List<ListarticleDto>();

    public void Map(Profile profile)=>profile.CreateMap<Commande,CommandeDto>().ReverseMap();
}