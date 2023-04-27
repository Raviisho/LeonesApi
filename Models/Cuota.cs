using LeonesApi.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeonesApi.Models;

public partial class Cuota
{
    [Key]
    public int Id { get; set; }
    [Required]
    public MesEnum Mes { get; set; }
    [Required]
    public int Año { get; set; }
    [Required]
    [Precision(12, 2)]
    public decimal Monto { get; set; }
    public bool Cobrada { get; set; }
    public int SocioId { get; set; }
    [ForeignKey("SocioId")]
    public Socio? Socio { get; set; } = null!;
    public int TesoreroId { get; set; }
    [ForeignKey("TesoreroId")]
    public Tesorero? Tesorero { get; set; } = null!;
}
