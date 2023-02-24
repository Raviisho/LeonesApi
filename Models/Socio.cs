using System;
using System.Collections.Generic;

namespace LeonesApi.Models;

public partial class Socio
{
    public int Id { get; set; }

    public string ApellidoNombre { get; set; } = null!;

    public string Dirección { get; set; } = null!;

    public string Teléfono { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public virtual ICollection<Cuota> Cuota { get; } = new List<Cuota>();
}
