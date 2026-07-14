using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Diagnostico
{
    public int IdDiagnostico { get; set; }

    public int IdExpediente { get; set; }

    public int IdVeterinario { get; set; }

    public string NombreDiagnostico { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Gravedad { get; set; } = null!;

    public virtual ExpedienteMedico IdExpedienteNavigation { get; set; } = null!;

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
