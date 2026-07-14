using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class ServicioCitum
{
    public int IdServicioCita { get; set; }

    public int IdServicio { get; set; }

    public int IdCita { get; set; }

    public virtual Citum IdCitaNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
