
using AutoMapper;
using Core.Models;

public partial class FouarticleDto:IMapForm<Fouarticle>
{
    public string Codefour { get; set; }

    public string Codeart { get; set; }

    public int? Qte { get; set; }

    public decimal? Prixht { get; set; }

    public virtual ArticleDto CodeartNavigation { get; set; }

    public virtual FournisseurDto CodefourNavigation { get; set; }

    public void Map(Profile profile)=>profile.CreateMap<Fouarticle,FouarticleDto>().ReverseMap();
}
