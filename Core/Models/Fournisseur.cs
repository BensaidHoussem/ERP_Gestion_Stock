using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Fournisseur
{
    public string Codefour { get; set; }

    public string Nom { get; set; }

    public string Tel { get; set; }

    public string Adresse { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Fouarticle> Fouarticles { get; set; } = new List<Fouarticle>();
}
