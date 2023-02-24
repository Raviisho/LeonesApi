using System;
using System.Collections.Generic;

namespace LeonesApi.Models;

public partial class Tesorero
{
    public int Id { get; set; }

    public string ApellidoNombre { get; set; } = null!;

    public string Período { get; set; } = null!;

    public virtual ICollection<Cuota> Cuota { get; } = new List<Cuota>();
}
