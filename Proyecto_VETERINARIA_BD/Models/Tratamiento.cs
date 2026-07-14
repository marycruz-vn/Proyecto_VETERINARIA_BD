using System;
using System.Collections.Generic;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public int IdDiagnostico { get; set; }

    public string NombreTratamiento { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int DuracionDias { get; set; }

    public virtual Diagnostico IdDiagnosticoNavigation { get; set; } = null!;

    public virtual ICollection<TratamientoProducto> TratamientoProductos { get; set; } = new List<TratamientoProducto>();
}
