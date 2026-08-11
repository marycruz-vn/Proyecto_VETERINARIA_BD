using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proyecto_VETERINARIA_BD.DTOs;
using System;
using System.Collections.Generic;
using static Proyecto_VETERINARIA_BD.DTOs.ProductoDto;

namespace Proyecto_VETERINARIA_BD.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Citum> Cita { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Diagnostico> Diagnosticos { get; set; }

    public virtual DbSet<ExpedienteMedico> ExpedienteMedicos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Mascotum> Mascota { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioCitum> ServicioCita { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<TratamientoProducto> TratamientoProductos { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__Cita__6AEC3C098E5B1447");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdVeterinario).HasColumnName("id_veterinario");
            entity.Property(e => e.Motivo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("motivo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cita__estado__693CA210");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cita__id_veterin__6A30C649");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__677F38F5D75014CE");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Correo, "UQ__Cliente__2A586E0BAC030D54").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnost__1384B745CDF0E710");

            entity.ToTable("Diagnostico");

            entity.Property(e => e.IdDiagnostico).HasColumnName("id_diagnostico");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Gravedad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gravedad");
            entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");
            entity.Property(e => e.IdVeterinario).HasColumnName("id_veterinario");
            entity.Property(e => e.NombreDiagnostico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_diagnostico");

            entity.HasOne(d => d.IdExpedienteNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdExpediente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diagnosti__grave__70DDC3D8");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.IdVeterinario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diagnosti__id_ve__71D1E811");
        });

        modelBuilder.Entity<ExpedienteMedico>(entity =>
        {
            entity.HasKey(e => e.IdExpediente).HasName("PK__Expedien__E75F5BDE5B564DB8");

            entity.ToTable("Expediente_Medico");

            entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.TratamientoGeneral)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("tratamiento_general");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.ExpedienteMedicos)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__id_ma__6D0D32F4");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PK__Inventar__013AEB51CE7A2C90");

            entity.ToTable("Inventario");

            entity.HasIndex(e => e.IdProducto, "UQ__Inventar__FF341C0C40379DB5").IsUnique();

            entity.Property(e => e.IdInventario).HasColumnName("id_inventario");
            entity.Property(e => e.CantidadStock).HasColumnName("cantidad_stock");
            entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.Inventario)
                .HasForeignKey<Inventario>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventari__id_pr__02FC7413");
        });

        modelBuilder.Entity<Mascotum>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__Mascota__6F037352168C33BF");

            entity.Property(e => e.IdMascota).HasColumnName("id_mascota");
            entity.Property(e => e.Alergias)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("alergias");
            entity.Property(e => e.Especie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("especie");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("peso");
            entity.Property(e => e.Raza)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("raza");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sexo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascota__id_clie__619B8048");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0D9FFE7A36");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.NombreProducto, "UQ__Producto__1424FB1DD6410C7E").IsUnique();

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__id_pro__7D439ABD");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE28423B98F7");

            entity.ToTable("Proveedor");

            entity.HasIndex(e => e.Correo, "UQ__Proveedo__2A586E0B188790D6").IsUnique();

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_empresa");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDCE2240088");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<ServicioCitum>(entity =>
        {
            entity.HasKey(e => e.IdServicioCita).HasName("PK__Servicio__C8A08425B6ABBBC4");

            entity.ToTable("Servicio_Cita");

            entity.Property(e => e.IdServicioCita).HasColumnName("id_servicio_cita");
            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.ServicioCita)
                .HasForeignKey(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicio___id_ci__09A971A2");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.ServicioCita)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicio___id_se__08B54D69");
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento).HasName("PK__Tratamie__C8825F4C3BC9CA9D");

            entity.ToTable("Tratamiento");

            entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.DuracionDias).HasColumnName("duracion_dias");
            entity.Property(e => e.IdDiagnostico).HasColumnName("id_diagnostico");
            entity.Property(e => e.NombreTratamiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tratamiento");

            entity.HasOne(d => d.IdDiagnosticoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdDiagnostico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__id_di__75A278F5");
        });

        modelBuilder.Entity<TratamientoProducto>(entity =>
        {
            entity.HasKey(e => e.IdTratamientoProducto).HasName("PK__Tratamie__58BD8F67AF245E8B");

            entity.ToTable("Tratamiento_Producto");

            entity.Property(e => e.IdTratamientoProducto).HasColumnName("id_tratamiento_producto");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TratamientoProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__id_pr__0D7A0286");

            entity.HasOne(d => d.IdTratamientoNavigation).WithMany(p => p.TratamientoProductos)
                .HasForeignKey(d => d.IdTratamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tratamien__id_tr__0C85DE4D");
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.IdVeterinario).HasName("PK__Veterina__16E06DFFF7AEEF30");

            entity.ToTable("Veterinario");

            entity.HasIndex(e => e.Correo, "UQ__Veterina__2A586E0B96CAE5B2").IsUnique();

            entity.Property(e => e.IdVeterinario).HasColumnName("id_veterinario");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    // LISTAR
    public async Task<List<CitaListarDto>> sp_Cita_Listar()
    {
        return await Database.SqlQueryRaw<CitaListarDto>(
            "EXEC sp_ListarCitas"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<CitaObtenerPorIDDto?> sp_Cita_ObtenerPorID(int idCita)
    {
        var result = await Database.SqlQueryRaw<CitaObtenerPorIDDto>(
            "EXEC sp_ObtenerCita @id_cita",
            new SqlParameter("@id_cita", idCita)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<CitaInsertarDto?> sp_Cita_Insertar(
        int idCliente,
        int idVeterinario,
        DateOnly fecha,
        TimeOnly hora,
        string motivo,
        string estado)
    {
        var result = await Database.SqlQueryRaw<CitaInsertarDto>(
            "EXEC sp_InsertarCita @id_cliente,@id_veterinario,@fecha,@hora,@motivo,@estado",
            new SqlParameter("@id_cliente", idCliente),
            new SqlParameter("@id_veterinario", idVeterinario),
            new SqlParameter("@fecha", fecha),
            new SqlParameter("@hora", hora),
            new SqlParameter("@motivo", motivo),
            new SqlParameter("@estado", estado)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<CitaActualizarDto?> sp_Cita_Actualizar(
        int idCita,
        int idCliente,
        int idVeterinario,
        DateOnly fecha,
        TimeOnly hora,
        string motivo,
        string estado)
    {
        var result = await Database.SqlQueryRaw<CitaActualizarDto>(
            "EXEC sp_ActualizarCita @id_cita,@id_cliente,@id_veterinario,@fecha,@hora,@motivo,@estado",
            new SqlParameter("@id_cita", idCita),
            new SqlParameter("@id_cliente", idCliente),
            new SqlParameter("@id_veterinario", idVeterinario),
            new SqlParameter("@fecha", fecha),
            new SqlParameter("@hora", hora),
            new SqlParameter("@motivo", motivo),
            new SqlParameter("@estado", estado)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<CitaEliminarDto?> sp_Cita_Eliminar(int idCita)
    {
        var result = await Database.SqlQueryRaw<CitaEliminarDto>(
            "EXEC sp_EliminarCita @id_cita",
            new SqlParameter("@id_cita", idCita)
        ).ToListAsync();

        return result.FirstOrDefault();
    }



    // LISTAR
    public async Task<List<ClienteListarDto>> sp_Cliente_Listar()
    {
        return await Database.SqlQueryRaw<ClienteListarDto>(
            "EXEC sp_ListarClientes"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<ClienteObtenerPorIDDto?> sp_Cliente_ObtenerPorID(int idCliente)
    {
        var result = await Database.SqlQueryRaw<ClienteObtenerPorIDDto>(
            "EXEC sp_ObtenerCliente @id_cliente",
            new SqlParameter("@id_cliente", idCliente)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<ClienteInsertarDto?> sp_Cliente_Insertar(
        string nombre,
        string apellido,
        string telefono,
        string correo,
        string direccion,
        DateOnly fechaRegistro)
    {
        var result = await Database.SqlQueryRaw<ClienteInsertarDto>(
            "EXEC sp_InsertarCliente @nombre,@apellido,@telefono,@correo,@direccion,@fecha_registro",
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@apellido", apellido),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@direccion", direccion),
            new SqlParameter("@fecha_registro", fechaRegistro)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<ClienteActualizarDto?> sp_Cliente_Actualizar(
        int idCliente,
        string nombre,
        string apellido,
        string telefono,
        string correo,
        string direccion)
    {
        var result = await Database.SqlQueryRaw<ClienteActualizarDto>(
            "EXEC sp_ActualizarCliente @id_cliente,@nombre,@apellido,@telefono,@correo,@direccion",
            new SqlParameter("@id_cliente", idCliente),
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@apellido", apellido),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@direccion", direccion)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<ClienteEliminarDto?> sp_Cliente_Eliminar(int idCliente)
    {
        var result = await Database.SqlQueryRaw<ClienteEliminarDto>(
            "EXEC sp_EliminarCliente @id_cliente",
            new SqlParameter("@id_cliente", idCliente)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // LISTAR
    public async Task<List<DiagnosticoListarDto>> sp_Diagnostico_Listar()
    {
        return await Database.SqlQueryRaw<DiagnosticoListarDto>(
            "EXEC sp_ListarDiagnosticos"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<DiagnosticoObtenerPorIDDto?> sp_Diagnostico_ObtenerPorID(int idDiagnostico)
    {
        var result = await Database.SqlQueryRaw<DiagnosticoObtenerPorIDDto>(
            "EXEC sp_ObtenerDiagnostico @id_diagnostico",
            new SqlParameter("@id_diagnostico", idDiagnostico)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<DiagnosticoInsertarDto?> sp_Diagnostico_Insertar(
        int idExpediente,
        int idVeterinario,
        string nombreDiagnostico,
        string descripcion,
        string gravedad)
    {
        var result = await Database.SqlQueryRaw<DiagnosticoInsertarDto>(
            "EXEC sp_InsertarDiagnostico @id_expediente,@id_veterinario,@nombre_diagnostico,@descripcion,@gravedad",
            new SqlParameter("@id_expediente", idExpediente),
            new SqlParameter("@id_veterinario", idVeterinario),
            new SqlParameter("@nombre_diagnostico", nombreDiagnostico),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@gravedad", gravedad)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<DiagnosticoActualizarDto?> sp_Diagnostico_Actualizar(
        int idDiagnostico,
        int idExpediente,
        int idVeterinario,
        string nombreDiagnostico,
        string descripcion,
        string gravedad)
    {
        var result = await Database.SqlQueryRaw<DiagnosticoActualizarDto>(
            "EXEC sp_ActualizarDiagnostico @id_diagnostico,@id_expediente,@id_veterinario,@nombre_diagnostico,@descripcion,@gravedad",
            new SqlParameter("@id_diagnostico", idDiagnostico),
            new SqlParameter("@id_expediente", idExpediente),
            new SqlParameter("@id_veterinario", idVeterinario),
            new SqlParameter("@nombre_diagnostico", nombreDiagnostico),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@gravedad", gravedad)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<DiagnosticoEliminarDto?> sp_Diagnostico_Eliminar(int idDiagnostico)
    {
        var result = await Database.SqlQueryRaw<DiagnosticoEliminarDto>(
            "EXEC sp_EliminarDiagnostico @id_diagnostico",
            new SqlParameter("@id_diagnostico", idDiagnostico)
        ).ToListAsync();

        return result.FirstOrDefault();
    }
    // LISTAR
    public async Task<List<ExpedienteListarDto>> sp_Expediente_Listar()
{
    return await Database.SqlQueryRaw<ExpedienteListarDto>(
        "EXEC sp_ListarExpedientes"
    ).ToListAsync();
}

// OBTENER POR ID
public async Task<ExpedienteObtenerPorIDDto?> sp_Expediente_ObtenerPorID(int idExpediente)
{
    var result = await Database.SqlQueryRaw<ExpedienteObtenerPorIDDto>(
        "EXEC sp_ObtenerExpediente @id_expediente",
        new SqlParameter("@id_expediente", idExpediente)
    ).ToListAsync();

    return result.FirstOrDefault();
}

// INSERTAR
public async Task<ExpedienteInsertarDto?> sp_Expediente_Insertar(
    int idMascota,
    DateOnly fecha,
    string observaciones,
    string tratamientoGeneral)
{
    var result = await Database.SqlQueryRaw<ExpedienteInsertarDto>(
        "EXEC sp_InsertarExpediente @id_mascota,@fecha,@observaciones,@tratamiento_general",
        new SqlParameter("@id_mascota", idMascota),
        new SqlParameter("@fecha", fecha),
        new SqlParameter("@observaciones", observaciones),
        new SqlParameter("@tratamiento_general", tratamientoGeneral)
    ).ToListAsync();

    return result.FirstOrDefault();
}

// ACTUALIZAR
public async Task<ExpedienteActualizarDto?> sp_Expediente_Actualizar(
    int idExpediente,
    int idMascota,
    DateOnly fecha,
    string observaciones,
    string tratamientoGeneral)
{
    var result = await Database.SqlQueryRaw<ExpedienteActualizarDto>(
        "EXEC sp_ActualizarExpediente @id_expediente,@id_mascota,@fecha,@observaciones,@tratamiento_general",
        new SqlParameter("@id_expediente", idExpediente),
        new SqlParameter("@id_mascota", idMascota),
        new SqlParameter("@fecha", fecha),
        new SqlParameter("@observaciones", observaciones),
        new SqlParameter("@tratamiento_general", tratamientoGeneral)
    ).ToListAsync();

    return result.FirstOrDefault();
}

// ELIMINAR
public async Task<ExpedienteEliminarDto?> sp_Expediente_Eliminar(int idExpediente)
{
    var result = await Database.SqlQueryRaw<ExpedienteEliminarDto>(
        "EXEC sp_EliminarExpediente @id_expediente",
        new SqlParameter("@id_expediente", idExpediente)
    ).ToListAsync();

    return result.FirstOrDefault();
}


    // LISTAR
    public async Task<List<InventarioListarDto>> sp_Inventario_Listar()
    {
        return await Database.SqlQueryRaw<InventarioListarDto>(
            "EXEC sp_ListarInventario"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<InventarioObtenerPorIDDto?> sp_Inventario_ObtenerPorID(int idInventario)
    {
        var result = await Database.SqlQueryRaw<InventarioObtenerPorIDDto>(
            "EXEC sp_ObtenerInventario @id_inventario",
            new SqlParameter("@id_inventario", idInventario)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<InventarioInsertarDto?> sp_Inventario_Insertar(
        int idProducto,
        int cantidadDisponible,
        int stockMinimo,
        DateTime fechaActualizacion)
    {
        var result = await Database.SqlQueryRaw<InventarioInsertarDto>(
            "EXEC sp_InsertarInventario @id_producto,@cantidad_disponible,@stock_minimo",
            new SqlParameter("@id_producto", idProducto),
            new SqlParameter("@cantidad_disponible", cantidadDisponible),
            new SqlParameter("@stock_minimo", stockMinimo)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<InventarioActualizarDto?> sp_Inventario_Actualizar(
        int idInventario,
        int idProducto,
        int cantidadDisponible,
        int stockMinimo,
        DateTime fechaActualizacion)
    {
        var result = await Database.SqlQueryRaw<InventarioActualizarDto>(
            "EXEC sp_ActualizarInventario @id_inventario,@id_producto,@cantidad_disponible,@stock_minimo",
            new SqlParameter("@id_inventario", idInventario),
            new SqlParameter("@id_producto", idProducto),
            new SqlParameter("@cantidad_disponible", cantidadDisponible),
            new SqlParameter("@stock_minimo", stockMinimo)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<InventarioEliminarDto?> sp_Inventario_Eliminar(int idInventario)
    {
        var result = await Database.SqlQueryRaw<InventarioEliminarDto>(
            "EXEC sp_EliminarInventario @id_inventario",
            new SqlParameter("@id_inventario", idInventario)
        ).ToListAsync();

        return result.FirstOrDefault();
    }




    // LISTAR
    public async Task<List<MascotaListarDto>> sp_Mascota_Listar()
    {
        return await Database.SqlQueryRaw<MascotaListarDto>(
            "EXEC sp_ListarMascotas"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<MascotaObtenerPorIDDto?> sp_Mascota_ObtenerPorID(int idMascota)
    {
        var result = await Database.SqlQueryRaw<MascotaObtenerPorIDDto>(
            "EXEC sp_ObtenerMascota @id_mascota",
            new SqlParameter("@id_mascota", idMascota)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<MascotaInsertarDto?> sp_Mascota_Insertar(
        int idCliente,
        string nombre,
        string especie,
        string raza,
        string sexo,
        DateOnly fechaNacimiento,
        decimal peso,
        string? alergias)
    {
        var result = await Database.SqlQueryRaw<MascotaInsertarDto>(
            "EXEC sp_InsertarMascota @id_cliente,@nombre,@especie,@raza,@sexo,@fecha_nacimiento,@peso,@alergias",
            new SqlParameter("@id_cliente", idCliente),
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@especie", especie),
            new SqlParameter("@raza", raza),
            new SqlParameter("@sexo", sexo),
            new SqlParameter("@fecha_nacimiento", fechaNacimiento),
            new SqlParameter("@peso", peso),
            new SqlParameter("@alergias", (object?)alergias ?? DBNull.Value)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<MascotaActualizarDto?> sp_Mascota_Actualizar(
        int idMascota,
        int idCliente,
        string nombre,
        string especie,
        string raza,
        string sexo,
        DateOnly fechaNacimiento,
        decimal peso,
        string? alergias)
    {
        var result = await Database.SqlQueryRaw<MascotaActualizarDto>(
            "EXEC sp_ActualizarMascota @id_mascota,@id_cliente,@nombre,@especie,@raza,@sexo,@fecha_nacimiento,@peso,@alergias",
            new SqlParameter("@id_mascota", idMascota),
            new SqlParameter("@id_cliente", idCliente),
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@especie", especie),
            new SqlParameter("@raza", raza),
            new SqlParameter("@sexo", sexo),
            new SqlParameter("@fecha_nacimiento", fechaNacimiento),
            new SqlParameter("@peso", peso),
            new SqlParameter("@alergias", (object?)alergias ?? DBNull.Value)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<MascotaEliminarDto?> sp_Mascota_Eliminar(int idMascota)
    {
        var result = await Database.SqlQueryRaw<MascotaEliminarDto>(
            "EXEC sp_EliminarMascota @id_mascota",
            new SqlParameter("@id_mascota", idMascota)
        ).ToListAsync();

        return result.FirstOrDefault();
    }


    // LISTAR
    public async Task<List<ProductoListarDto>> sp_Producto_Listar(string? nombreProducto, string? categoria, int pageNumber, int pageSize)
    {
        return await Database.SqlQueryRaw<ProductoListarDto>(
            "EXEC sp_ListarProducto"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<ProductoObtenerPorIDDto?> sp_Producto_ObtenerPorID(int idProducto)
    {
        var result = await Database.SqlQueryRaw<ProductoObtenerPorIDDto>(
            "EXEC sp_ObtenerProducto @id_producto",
            new SqlParameter("@id_producto", idProducto)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR 
    public async Task<ProductoInsertarDto?> sp_Producto_Insertar(
        string nombreProducto,
        string categoria,
        string? descripcion,
        decimal precio,
        DateOnly? fechaVencimiento,
        int idProveedor)
    {
        var result = await Database.SqlQueryRaw<ProductoInsertarDto>(
            "EXEC sp_InsertarProducto @nombre_producto, @categoria, @descripcion, @precio, @fecha_vencimiento, @id_proveedor",
            new SqlParameter("@nombre_producto", nombreProducto),
            new SqlParameter("@categoria", categoria),
            new SqlParameter("@descripcion", (object?)descripcion ?? DBNull.Value),
            new SqlParameter("@precio", precio),
            new SqlParameter("@fecha_vencimiento", (object?)fechaVencimiento ?? DBNull.Value),
            new SqlParameter("@id_proveedor", idProveedor)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<ProductoActualizarDto?> sp_Producto_Actualizar(
        int idProducto,
        string nombreProducto,
        string categoria,
        string? descripcion,
        decimal precio,
        DateOnly? fechaVencimiento,
        int idProveedor)
    {
        var result = await Database.SqlQueryRaw<ProductoActualizarDto>(
            "EXEC sp_ActualizarProducto @id_producto, @nombre_producto, @categoria, @descripcion, @precio, @fecha_vencimiento, @id_proveedor",
            new SqlParameter("@id_producto", idProducto),
            new SqlParameter("@nombre_producto", nombreProducto),
            new SqlParameter("@categoria", categoria),
            new SqlParameter("@descripcion", (object?)descripcion ?? DBNull.Value),
            new SqlParameter("@precio", precio),
            new SqlParameter("@fecha_vencimiento", (object?)fechaVencimiento ?? DBNull.Value),
            new SqlParameter("@id_proveedor", idProveedor)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<ProductoEliminarDto?> sp_Producto_Eliminar(int idProducto)
    {
        var result = await Database.SqlQueryRaw<ProductoEliminarDto>(
            "EXEC sp_EliminarProducto @id_producto",
            new SqlParameter("@id_producto", idProducto)
        ).ToListAsync();

        return result.FirstOrDefault();
    }


    // LISTAR
    public async Task<List<ProveedorListarDto>> sp_Proveedor_Listar()
    {
        return await Database.SqlQueryRaw<ProveedorListarDto>(
            "EXEC sp_ListarProveedores"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<ProveedorObtenerPorIDDto?> sp_Proveedor_ObtenerPorID(int idProveedor)
    {
        var result = await Database.SqlQueryRaw<ProveedorObtenerPorIDDto>(
            "EXEC sp_ObtenerProveedor @id_proveedor",
            new SqlParameter("@id_proveedor", idProveedor)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<ProveedorInsertarDto?> sp_Proveedor_Insertar(
        string nombreEmpresa,
        string telefono,
        string correo,
        string direccion)
    {
        var result = await Database.SqlQueryRaw<ProveedorInsertarDto>(
            "EXEC sp_InsertarProveedor @nombre_empresa,@telefono,@correo,@direccion",
            new SqlParameter("@nombre_empresa", nombreEmpresa),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@direccion", direccion)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<ProveedorActualizarDto?> sp_Proveedor_Actualizar(
        int idProveedor,
        string nombreEmpresa,
        string telefono,
        string correo,
        string direccion)
    {
        var result = await Database.SqlQueryRaw<ProveedorActualizarDto>(
            "EXEC sp_ActualizarProveedor @id_proveedor,@nombre_empresa,@telefono,@correo,@direccion",
            new SqlParameter("@id_proveedor", idProveedor),
            new SqlParameter("@nombre_empresa", nombreEmpresa),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@direccion", direccion)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<ProveedorEliminarDto?> sp_Proveedor_Eliminar(int idProveedor)
    {
        var result = await Database.SqlQueryRaw<ProveedorEliminarDto>(
            "EXEC sp_EliminarProveedor @id_proveedor",
            new SqlParameter("@id_proveedor", idProveedor)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // LISTAR
    public async Task<List<ServicioListarDto>> sp_Servicio_Listar()
    {
        return await Database.SqlQueryRaw<ServicioListarDto>(
            "EXEC sp_ListarServicios"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<ServicioObtenerPorIDDto?> sp_Servicio_ObtenerPorID(int idServicio)
    {
        var result = await Database.SqlQueryRaw<ServicioObtenerPorIDDto>(
            "EXEC sp_ObtenerServicio @id_servicio",
            new SqlParameter("@id_servicio", idServicio)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<ServicioInsertarDto?> sp_Servicio_Insertar(
        string nombreServicio,
        string descripcion,
        decimal precio)
    {
        var result = await Database.SqlQueryRaw<ServicioInsertarDto>(
            "EXEC sp_InsertarServicio @nombre_servicio,@descripcion,@precio",
            new SqlParameter("@nombre_servicio", nombreServicio),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@precio", precio)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<ServicioActualizarDto?> sp_Servicio_Actualizar(
        int idServicio,
        string nombreServicio,
        string descripcion,
        decimal precio)
    {
        var result = await Database.SqlQueryRaw<ServicioActualizarDto>(
            "EXEC sp_ActualizarServicio @id_servicio,@nombre_servicio,@descripcion,@precio",
            new SqlParameter("@id_servicio", idServicio),
            new SqlParameter("@nombre_servicio", nombreServicio),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@precio", precio)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<ServicioEliminarDto?> sp_Servicio_Eliminar(int idServicio)
    {
        var result = await Database.SqlQueryRaw<ServicioEliminarDto>(
            "EXEC sp_EliminarServicio @id_servicio",
            new SqlParameter("@id_servicio", idServicio)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // LISTAR
    public async Task<List<TratamientoListarDto>> sp_Tratamiento_Listar()
    {
        return await Database.SqlQueryRaw<TratamientoListarDto>(
            "EXEC sp_ListarTratamientos"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<TratamientoObtenerPorIDDto?> sp_Tratamiento_ObtenerPorID(int idTratamiento)
    {
        var result = await Database.SqlQueryRaw<TratamientoObtenerPorIDDto>(
            "EXEC sp_ObtenerTratamiento @id_tratamiento",
            new SqlParameter("@id_tratamiento", idTratamiento)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<TratamientoInsertarDto?> sp_Tratamiento_Insertar(
        int idDiagnostico,
        string nombreTratamiento,
        string descripcion,
        int duracionDias)
    {
        var result = await Database.SqlQueryRaw<TratamientoInsertarDto>(
            "EXEC sp_InsertarTratamiento @id_diagnostico,@nombre_tratamiento,@descripcion,@duracion_dias",
            new SqlParameter("@id_diagnostico", idDiagnostico),
            new SqlParameter("@nombre_tratamiento", nombreTratamiento),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@duracion_dias", duracionDias)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<TratamientoActualizarDto?> sp_Tratamiento_Actualizar(
        int idTratamiento,
        int idDiagnostico,
        string nombreTratamiento,
        string descripcion,
        int duracionDias)
    {
        var result = await Database.SqlQueryRaw<TratamientoActualizarDto>(
            "EXEC sp_ActualizarTratamiento @id_tratamiento,@id_diagnostico,@nombre_tratamiento,@descripcion,@duracion_dias",
            new SqlParameter("@id_tratamiento", idTratamiento),
            new SqlParameter("@id_diagnostico", idDiagnostico),
            new SqlParameter("@nombre_tratamiento", nombreTratamiento),
            new SqlParameter("@descripcion", descripcion),
            new SqlParameter("@duracion_dias", duracionDias)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<TratamientoEliminarDto?> sp_Tratamiento_Eliminar(int idTratamiento)
    {
        var result = await Database.SqlQueryRaw<TratamientoEliminarDto>(
            "EXEC sp_EliminarTratamiento @id_tratamiento",
            new SqlParameter("@id_tratamiento", idTratamiento)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // LISTAR
    public async Task<List<VeterinarioListarDto>> sp_Veterinario_Listar()
    {
        return await Database.SqlQueryRaw<VeterinarioListarDto>(
            "EXEC sp_ListarVeterinarios"
        ).ToListAsync();
    }

    // OBTENER POR ID
    public async Task<VeterinarioObtenerPorIDDto?> sp_Veterinario_ObtenerPorID(int idVeterinario)
    {
        var result = await Database.SqlQueryRaw<VeterinarioObtenerPorIDDto>(
            "EXEC sp_ObtenerVeterinario @id_veterinario",
            new SqlParameter("@id_veterinario", idVeterinario)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // INSERTAR
    public async Task<VeterinarioInsertarDto?> sp_Veterinario_Insertar(
        string nombre,
        string especialidad,
        string telefono,
        string correo,
        string estado)
    {
        var result = await Database.SqlQueryRaw<VeterinarioInsertarDto>(
            "EXEC sp_InsertarVeterinario @nombre,@especialidad,@telefono,@correo,@estado",
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@especialidad", especialidad),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@estado", estado)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ACTUALIZAR
    public async Task<VeterinarioActualizarDto?> sp_Veterinario_Actualizar(
        int idVeterinario,
        string nombre,
        string especialidad,
        string telefono,
        string correo,
        string estado)
    {
        var result = await Database.SqlQueryRaw<VeterinarioActualizarDto>(
            "EXEC sp_ActualizarVeterinario @id_veterinario,@nombre,@especialidad,@telefono,@correo,@estado",
            new SqlParameter("@id_veterinario", idVeterinario),
            new SqlParameter("@nombre", nombre),
            new SqlParameter("@especialidad", especialidad),
            new SqlParameter("@telefono", telefono),
            new SqlParameter("@correo", correo),
            new SqlParameter("@estado", estado)
        ).ToListAsync();

        return result.FirstOrDefault();
    }

    // ELIMINAR
    public async Task<VeterinarioEliminarDto?> sp_Veterinario_Eliminar(int idVeterinario)
    {
        var result = await Database.SqlQueryRaw<VeterinarioEliminarDto>(
            "EXEC sp_EliminarVeterinario @id_veterinario",
            new SqlParameter("@id_veterinario", idVeterinario)
        ).ToListAsync();

        return result.FirstOrDefault();
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
}
