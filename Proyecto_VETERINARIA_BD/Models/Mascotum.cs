using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Mascotum
{
    public int IdMascota { get; set; }

    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Especie { get; set; } = null!;

    public string? Raza { get; set; }

    public string Sexo { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? Peso { get; set; }

    public string? Alergias { get; set; }

    public virtual ICollection<ExpedienteMedico> ExpedienteMedicos { get; set; } = new List<ExpedienteMedico>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
