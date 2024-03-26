

using AutoMapper;
using Core.Models;

public partial class ListarticleDto:IMapForm<Listarticle>
{
    public string Numcmd { get; set; }

    public string Codeart { get; set; }

    public int? Qte { get; set; }

    public decimal? Prixht { get; set; }

    public virtual ArticleDto CodeartNavigation { get; set; }

    public virtual CommandeDto NumcmdNavigation { get; set; }

    public void Map(Profile profile)=>profile.CreateMap<Listarticle,ListarticleDto>().ReverseMap();
}
