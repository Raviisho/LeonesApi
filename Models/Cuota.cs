using System;
using System.Collections.Generic;

namespace LeonesApi.Models;

public partial class Cuota
{
    public int Id { get; set; }

    public int Mes { get; set; }

    public int Año { get; set; }

    public decimal Monto { get; set; }

    public bool Cobrada { get; set; }

    public int SocioId { get; set; }

    public int? TesoreroId { get; set; }

    public virtual Socio Socio { get; set; } = null!;

    public virtual Tesorero? Tesorero { get; set; }
}
