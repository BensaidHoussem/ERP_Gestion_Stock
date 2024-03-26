using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Client
{
    public string Codeclient { get; set; }

    public string Nom { get; set; }

    public string Adresse { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Commande> Commandes { get; set; } = new List<Commande>();
}
