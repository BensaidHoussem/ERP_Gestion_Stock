using AutoMapper;
using Core.Models;

public partial class ArticleDto:IMapForm<Article>
{
    public string Codeart { get; set; }

    public string Libelle { get; set; }

    public int? Qte { get; set; }

    public decimal? Prix { get; set; }

    public virtual ICollection<FouarticleDto> Fouarticles { get; set; } = new List<FouarticleDto>();

    public virtual ICollection<ListarticleDto> Listarticles { get; set; } = new List<ListarticleDto>();



    public void Map(Profile profile)=>profile.CreateMap<Article,ArticleDto>().ReverseMap();
}