using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<ServicioCitum> ServicioCita { get; set; } = new List<ServicioCitum>();
}
