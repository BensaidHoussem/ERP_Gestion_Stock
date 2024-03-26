using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Listarticle
{
    public string Numcmd { get; set; }

    public string Codeart { get; set; }

    public int? Qte { get; set; }

    public decimal? Prixht { get; set; }

    public virtual Article CodeartNavigation { get; set; }

    public virtual Commande NumcmdNavigation { get; set; }
}
