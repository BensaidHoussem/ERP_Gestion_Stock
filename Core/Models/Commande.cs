using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Commande
{
    public string Numcmd { get; set; }

    public string Codeclient { get; set; }

    public DateOnly? Datecmd { get; set; }

    public decimal? Prix { get; set; }

    public decimal? Tva { get; set; }

    public decimal? Prixttc { get; set; }

    public virtual Client CodeclientNavigation { get; set; }

    public virtual ICollection<Listarticle> Listarticles { get; set; } = new List<Listarticle>();
}
