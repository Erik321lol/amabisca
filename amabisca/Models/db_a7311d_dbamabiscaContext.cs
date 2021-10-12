using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace amabisca.Models
{
    public partial class db_a7311d_dbamabiscaContext : DbContext
    {
        public db_a7311d_dbamabiscaContext()
        {
        }

        public db_a7311d_dbamabiscaContext(DbContextOptions<db_a7311d_dbamabiscaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<RolUsuario> RolUsuarios { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }
        public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source = SQL5108.site4now.net; Initial catalog = db_a7a914_dbamabisca; user id = db_a7a914_dbamabisca_admin; password = IngenierO22;");
            }
        }

        public static string dda = "Data Source=SQL5108.site4now.net;Initial Catalog=db_a7a914_dbamabisca;User Id=db_a7a914_dbamabisca_admin; password = IngenierO22;";
        public static SqlConnection con = new SqlConnection(dda);
       
        public static void abrir()
        {
            try
            {
                con.Open();
            }
            catch
            {
                Console.WriteLine("no funca");
                
            }

        }

        public static void cerrar()
        {
            try
            {
                con.Close();
            }
            catch
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK__cliente__08ED61F395C8F27E");

                entity.ToTable("cliente");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dpi).HasColumnName("dpi");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre1");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre2");

                entity.Property(e => e.Nombre3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre3");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.CodFactura)
                    .HasName("PK__factura__94EEA4100ABF4861");

                entity.ToTable("factura");

                entity.Property(e => e.CodFactura).HasColumnName("cod_factura");

                entity.Property(e => e.CodVenta).HasColumnName("cod_venta");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.CodVentaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__factura__cod_ven__3A81B327");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.CodInventario)
                    .HasName("PK__inventar__C117239A0F27FA7A");

                entity.ToTable("inventario");

                entity.Property(e => e.CodInventario).HasColumnName("cod_inventario");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventari__cod_p__3D5E1FD2");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodProducto)
                    .HasName("PK__producto__118203ADCC3F04FB");

                entity.ToTable("producto");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodProveedor).HasColumnName("cod_proveedor");

                entity.Property(e => e.CodTipoVehiculo).HasColumnName("cod_tipo_vehiculo");

                entity.Property(e => e.CodUnidadMedida).HasColumnName("cod_unidad_medida");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Medida)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("medida");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.CodProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__cod_pr__2E1BDC42");

                entity.HasOne(d => d.CodTipoVehiculoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodTipoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__cod_ti__2F10007B");

                entity.HasOne(d => d.CodUnidadMedidaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodUnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__cod_un__300424B4");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.CodProveedor)
                    .HasName("PK__proveedo__D4A662EB28990BA7");

                entity.ToTable("proveedor");

                entity.Property(e => e.CodProveedor).HasColumnName("cod_proveedor");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasKey(e => e.CodRolUsuario)
                    .HasName("PK__rol_usua__23049861BB8DD002");

                entity.ToTable("rol_usuario");

                entity.Property(e => e.CodRolUsuario).HasColumnName("cod_rol_usuario");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_rol");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.CodTipoVehiculo)
                    .HasName("PK__tipo_veh__9D88E2ACBE6AAEAC");

                entity.ToTable("tipo_vehiculo");

                entity.Property(e => e.CodTipoVehiculo).HasColumnName("cod_tipo_vehiculo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<UnidadMedidum>(entity =>
            {
                entity.HasKey(e => e.CodUnidadMedida)
                    .HasName("PK__unidad_m__707C8396774C4609");

                entity.ToTable("unidad_medida");

                entity.Property(e => e.CodUnidadMedida).HasColumnName("cod_unidad_medida");

                entity.Property(e => e.NombreUnidadMedida)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre_unidad_medida");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("PK__usuario__EA3C9B1A7D8DE34E");

                entity.ToTable("usuario");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("apellido2");

                entity.Property(e => e.CodRolUsuario).HasColumnName("cod_rol_usuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Dpi).HasColumnName("dpi");

                entity.Property(e => e.Nombre1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre1");

                entity.Property(e => e.Nombre2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre2");

                entity.Property(e => e.Nombre3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre3");

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.CodRolUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodRolUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__usuario__cod_rol__32E0915F");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.CodVenta)
                    .HasName("PK__venta__27326095A4A2C4F7");

                entity.ToTable("venta");

                entity.Property(e => e.CodVenta).HasColumnName("cod_venta");

                entity.Property(e => e.CantidadVenta)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cantidad_venta");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.CodProducto).HasColumnName("cod_producto");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.HasOne(d => d.CodClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CodCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__cod_clien__35BCFE0A");

                entity.HasOne(d => d.CodProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CodProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__cod_produ__36B12243");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__cod_usuar__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
