namespace Proyecto_VETERINARIA_BD.DTOs
{
    public class Tratamiento
    {
    }

        public class TratamientoListarDto
        {
            public string? NombreTratamiento { get; set; }
            public int? IdDiagnostico { get; set; }
            public int PageNumber { get; set; } = 1;
            public int PageSize { get; set; } = 20;
        }

        public class TratamientoObtenerPorIDDto
        {
            public int IdTratamiento { get; set; }
        }

        public class TratamientoInsertarDto
        {
            public int IdDiagnostico { get; set; }
            public string NombreTratamiento { get; set; } = null!;
            public string? Descripcion { get; set; }
            public int DuracionDias { get; set; }
        }

        public class TratamientoActualizarDto : TratamientoInsertarDto
        {
            public int IdTratamiento { get; set; }
        }

        public class TratamientoEliminarDto
        {
            public int IdTratamiento { get; set; }
        }
    }
