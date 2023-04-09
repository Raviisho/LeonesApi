using Desktop.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeonesApi.Models;

public partial class Cuota
{
    public int Id { get; set; }

    public MesEnum Mes { get; set; }

    public int Año { get; set; }

    public decimal Monto { get; set; }

    public bool Cobrada { get; set; }

    public int SocioId { get; set; }
    [ForeignKey("SocioId")]
    public Socio Socio { get; set; } = null!;

    public int TesoreroId { get; set; }
    [ForeignKey("TesoreroId")]
    public Tesorero? Tesorero { get; set; }
}
