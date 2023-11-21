using System;
using System.Collections.Generic;

namespace LeonesApi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int TipoUsuario { get; set; }

    public byte[]? Imagen { get; set; }

}
