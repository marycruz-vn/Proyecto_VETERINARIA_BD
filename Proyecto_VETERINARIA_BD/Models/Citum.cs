using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Citum
{
    public int IdCita { get; set; }

    public int IdCliente { get; set; }

    public int IdVeterinario { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Motivo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Veterinario IdVeterinarioNavigation { get; set; } = null!;

    public virtual ICollection<ServicioCitum> ServicioCita { get; set; } = new List<ServicioCitum>();
}
