using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MARYCRUZ\\SQLEXPRESS;Database=_VETERINARIA;Trusted_Connection=True;TrustServerCertificate=True;");

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

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
