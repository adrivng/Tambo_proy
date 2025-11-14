using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_TAMBOv2.Models;

public partial class TamboContext : DbContext
{
    public TamboContext()
    {
    }

    public TamboContext(DbContextOptions<TamboContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacens { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CompraCliente> CompraClientes { get; set; }

    public virtual DbSet<CuentaCliente> CuentaClientes { get; set; }

    public virtual DbSet<CuentaEmpleado> CuentaEmpleados { get; set; }

    public virtual DbSet<DetalleAlmacen> DetalleAlmacens { get; set; }

    public virtual DbSet<DetalleGuiasalidum> DetalleGuiasalida { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetalleOrdencompra1> DetalleOrdencompras { get; set; }

    public virtual DbSet<DetalleOrdenentradum> DetalleOrdenentrada { get; set; }

    public virtual DbSet<DetalleTicket> DetalleTickets { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<GuiaEntradum> GuiaEntrada { get; set; }

    public virtual DbSet<GuiaSalidum> GuiaSalida { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<TicketElectronico> TicketElectronicos { get; set; }

    public virtual DbSet<VentasRealizada> VentasRealizadas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FFSL0L1\\SQLEXPRESS;Database=Tambo;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK_almacen_idAlmacen");

            entity.ToTable("almacen", "dbtambo_fisico");

            entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK_categoria_idCategoria");

            entity.ToTable("categoria", "dbtambo_fisico");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_cliente_idCliente");

            entity.ToTable("cliente", "dbtambo_fisico");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Dni)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("dni");
            entity.Property(e => e.IdCuentaCliente)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idCuentaCliente");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .HasDefaultValueSql("(NULL)")
                .IsFixedLength()
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("telefono");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(10)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<CompraCliente>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK_compra_cliente_idCompra");

            entity.ToTable("compra_cliente", "dbtambo_fisico");

            entity.Property(e => e.IdCompra)
                .ValueGeneratedNever()
                .HasColumnName("idCompra");
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaCompra)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_compra");
            entity.Property(e => e.IdCliente)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idCliente");
        });

        modelBuilder.Entity<CuentaCliente>(entity =>
        {
            entity.HasKey(e => e.IdCuentaCliente).HasName("PK_cuenta_cliente_idCuentaCliente");

            entity.ToTable("cuenta_cliente", "dbtambo_fisico");

            entity.Property(e => e.IdCuentaCliente).HasColumnName("idCuentaCliente");
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasPrecision(0)
                .HasColumnName("Fecha_registro");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<CuentaEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdCuentaEmpleado).HasName("PK_cuenta_empleado_idCuenta_Empleado");

            entity.ToTable("cuenta_empleado", "dbtambo_fisico");

            entity.Property(e => e.IdCuentaEmpleado).HasColumnName("idCuenta_Empleado");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaRegistro)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_registro");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<DetalleAlmacen>(entity =>
        {
            entity.HasKey(e => e.IdAlmacen).HasName("PK_detalle_almacen_idAlmacen");

            entity.ToTable("detalle_almacen", "dbtambo_fisico");

            entity.Property(e => e.IdAlmacen)
                .ValueGeneratedNever()
                .HasColumnName("idAlmacen");
            entity.Property(e => e.IdProducto)
                .HasMaxLength(45)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idProducto");
        });

        modelBuilder.Entity<DetalleGuiasalidum>(entity =>
        {
            entity.HasKey(e => new { e.IdSalida, e.IdProducto }).HasName("PK_detalle_guiasalida_idSalida");

            entity.ToTable("detalle_guiasalida", "dbtambo_fisico");

            entity.Property(e => e.IdSalida)
                .ValueGeneratedOnAdd()
                .HasColumnName("idSalida");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("detalle_orden_compra", "dbtambo_fisico");

            entity.Property(e => e.Cantidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdOrdenCompra)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idOrden_compra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Importe)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<DetalleOrdencompra1>(entity =>
        {
            entity.HasKey(e => new { e.IdOrdenCompra, e.IdProducto }).HasName("PK_detalle_ordencompra_idOrden_Compra");

            entity.ToTable("detalle_ordencompra", "dbtambo_fisico");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrden_Compra");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<DetalleOrdenentradum>(entity =>
        {
            entity.HasKey(e => new { e.IdOrdenEntrada, e.IdProducto }).HasName("PK_detalle_ordenentrada_idOrden_Entrada");

            entity.ToTable("detalle_ordenentrada", "dbtambo_fisico");

            entity.Property(e => e.IdOrdenEntrada)
                .ValueGeneratedOnAdd()
                .HasColumnName("idOrden_Entrada");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad).HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<DetalleTicket>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK_detalle_ticket_idDetalle");

            entity.ToTable("detalle_ticket", "dbtambo_fisico");

            entity.Property(e => e.IdDetalle).HasColumnName("idDetalle");
            entity.Property(e => e.Cantidad).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IdProducto)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idProducto");
            entity.Property(e => e.IdTicket)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idTicket");
            entity.Property(e => e.Importe)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 0)");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_empleado_idEmpleado");

            entity.ToTable("empleado", "dbtambo_fisico");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaContratacion)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_Contratacion");
            entity.Property(e => e.IdCuentaEmpleado)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idCuenta_Empleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Salario)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Telefono)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<GuiaEntradum>(entity =>
        {
            entity.HasKey(e => e.IdEntrada).HasName("PK_guia_entrada_idEntrada");

            entity.ToTable("guia_entrada", "dbtambo_fisico");

            entity.Property(e => e.IdEntrada)
                .ValueGeneratedNever()
                .HasColumnName("idEntrada");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaEntrada)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_Entrada");
        });

        modelBuilder.Entity<GuiaSalidum>(entity =>
        {
            entity.HasKey(e => e.IdGuiaSalida).HasName("PK_guia_salida_idGuia_Salida");

            entity.ToTable("guia_salida", "dbtambo_fisico");

            entity.Property(e => e.IdGuiaSalida)
                .ValueGeneratedNever()
                .HasColumnName("idGuia_Salida");
            entity.Property(e => e.FechaSalida)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_Salida");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK_marca_idMarca");

            entity.ToTable("marca", "dbtambo_fisico");

            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK_orden_compra_idOrden_Compra");

            entity.ToTable("orden_compra", "dbtambo_fisico");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("idOrden_Compra");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_compra");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_producto_idProducto");

            entity.ToTable("producto", "dbtambo_fisico");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.FechaExpiracion)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Fecha_expiracion");
            entity.Property(e => e.IdCategoria)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.IdMarca)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idMarca");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 0)")
                .HasColumnName("Precio_unitario");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK_Producto_Marca");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK_proveedor_idProveedor");

            entity.ToTable("proveedor", "dbtambo_fisico");

            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("correo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<TicketElectronico>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK_ticket_electronico_idTicket");

            entity.ToTable("ticket_electronico", "dbtambo_fisico");

            entity.Property(e => e.IdTicket).HasColumnName("idTicket");
            entity.Property(e => e.FechaEmision)
                .HasPrecision(0)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fecha:_emision");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(45)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("forma_pago");
            entity.Property(e => e.Igv)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("igv");
            entity.Property(e => e.Subtotal).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<VentasRealizada>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK_ventas_realizadas_idVenta");

            entity.ToTable("ventas_realizadas", "dbtambo_fisico");

            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.IdEmpleado)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idEmpleado");
            entity.Property(e => e.IdTicket)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("idTicket");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
