using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Fouarticle
{
    public string Codefour { get; set; }

    public string Codeart { get; set; }

    public int? Qte { get; set; }

    public decimal? Prixht { get; set; }

    public virtual Article CodeartNavigation { get; set; }

    public virtual Fournisseur CodefourNavigation { get; set; }
}
