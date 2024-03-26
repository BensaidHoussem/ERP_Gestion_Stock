using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Article
{
    public string Codeart { get; set; }

    public string Libelle { get; set; }

    public int? Qte { get; set; }

    public decimal? Prix { get; set; }

    public virtual ICollection<Fouarticle> Fouarticles { get; set; } = new List<Fouarticle>();

    public virtual ICollection<Listarticle> Listarticles { get; set; } = new List<Listarticle>();
}
