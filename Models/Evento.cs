using System;
using System.Collections.Generic;

namespace LeonesApi.Models;

public partial class Evento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public decimal Ingreso { get; set; }

    public decimal Egreso { get; set; }
}
