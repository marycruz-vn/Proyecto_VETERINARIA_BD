using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class ExpedienteMedico
{
    public int IdExpediente { get; set; }

    public int IdMascota { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Observaciones { get; set; }

    public string? TratamientoGeneral { get; set; }

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

    public virtual Mascotum IdMascotaNavigation { get; set; } = null!;
}
