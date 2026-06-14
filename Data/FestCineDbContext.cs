using FestCineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FestCineApi.Data;

public class FestCineDbContext : DbContext
{
    public FestCineDbContext(DbContextOptions<FestCineDbContext> options) : base(options) { }

    public DbSet<Persona> Personas => Set<Persona>();
    public DbSet<Edicion> Ediciones => Set<Edicion>();
    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
    public DbSet<PeliculaEdicion> PeliculaEdiciones => Set<PeliculaEdicion>();
    public DbSet<Genero> Generos => Set<Genero>();
    public DbSet<PeliculaGenero> PeliculaGeneros => Set<PeliculaGenero>();
    public DbSet<PersonalCinematografico> PersonalCinematografico => Set<PersonalCinematografico>();
    public DbSet<RolCinematografico> RolesCinematograficos => Set<RolCinematografico>();
    public DbSet<ParticipacionPelicula> ParticipacionesPelicula => Set<ParticipacionPelicula>();
    public DbSet<Patrocinador> Patrocinadores => Set<Patrocinador>();
    public DbSet<Patrocinio> Patrocinios => Set<Patrocinio>();
    public DbSet<Sede> Sedes => Set<Sede>();
    public DbSet<SedeEdicion> SedeEdiciones => Set<SedeEdicion>();
    public DbSet<Sala> Salas => Set<Sala>();
    public DbSet<Proyeccion> Proyecciones => Set<Proyeccion>();
    public DbSet<Expositor> Expositores => Set<Expositor>();
    public DbSet<EventoParalelo> EventosParalelos => Set<EventoParalelo>();
    public DbSet<EventoExpositor> EventoExpositores => Set<EventoExpositor>();
    public DbSet<Asistente> Asistentes => Set<Asistente>();
    public DbSet<TipoAcreditacion> TipoAcreditaciones => Set<TipoAcreditacion>();
    public DbSet<Acreditacion> Acreditaciones => Set<Acreditacion>();
    public DbSet<Alojamiento> Alojamientos => Set<Alojamiento>();
    public DbSet<Traslado> Traslados => Set<Traslado>();
    public DbSet<Compra> Compras => Set<Compra>();
    public DbSet<Tarifa> Tarifas => Set<Tarifa>();
    public DbSet<Factura> Facturas => Set<Factura>();
    public DbSet<TipoAbono> TipoAbonos => Set<TipoAbono>();
    public DbSet<Abono> Abonos => Set<Abono>();
    public DbSet<AbonoProyeccion> AbonoProyecciones => Set<AbonoProyeccion>();
    public DbSet<EntradaIndividual> EntradasIndividuales => Set<EntradaIndividual>();
    public DbSet<AsistenciaProyeccion> AsistenciasProyeccion => Set<AsistenciaProyeccion>();
    public DbSet<Jurado> Jurados => Set<Jurado>();
    public DbSet<CategoriaCompeticion> CategoriasCompeticion => Set<CategoriaCompeticion>();
    public DbSet<CategoriaJurado> CategoriaJurados => Set<CategoriaJurado>();
    public DbSet<PeliculaCompite> PeliculasCompiten => Set<PeliculaCompite>();
    public DbSet<Evaluacion> Evaluaciones => Set<Evaluacion>();
    public DbSet<Premio> Premios => Set<Premio>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>().ToTable("Persona").HasKey(x => x.IdPersona);
        modelBuilder.Entity<Edicion>().ToTable("Edicion").HasKey(x => x.IdEdicion);
        modelBuilder.Entity<Pelicula>().ToTable("Pelicula").HasKey(x => x.IdPelicula);
        modelBuilder.Entity<PeliculaEdicion>().ToTable("PeliculaEdicion").HasKey(x => x.IdPeliculaEdicion);
        modelBuilder.Entity<Genero>().ToTable("Genero").HasKey(x => x.IdGenero);
        modelBuilder.Entity<PeliculaGenero>().ToTable("PeliculaGenero").HasKey(x => new { x.IdPelicula, x.IdGenero });
        modelBuilder.Entity<PersonalCinematografico>().ToTable("PersonalCinematografico").HasKey(x => x.IdPersonal);
        modelBuilder.Entity<RolCinematografico>().ToTable("RolCinematografico").HasKey(x => x.IdRol);
        modelBuilder.Entity<ParticipacionPelicula>().ToTable("ParticipacionPelicula").HasKey(x => new { x.IdPersonal, x.IdPelicula, x.IdRol });
        modelBuilder.Entity<Patrocinador>().ToTable("Patrocinador").HasKey(x => x.IdPatrocinador);
        modelBuilder.Entity<Patrocinio>().ToTable("Patrocinio").HasKey(x => x.IdPatrocinio);
        modelBuilder.Entity<Sede>().ToTable("Sede").HasKey(x => x.IdSede);
        modelBuilder.Entity<SedeEdicion>().ToTable("SedeEdicion").HasKey(x => new { x.IdSede, x.IdEdicion });
        modelBuilder.Entity<Sala>().ToTable("Salas").HasKey(x => x.IdSala);
        modelBuilder.Entity<Proyeccion>().ToTable("Proyecciones").HasKey(x => x.IdProyeccion);
        modelBuilder.Entity<Expositor>().ToTable("Expositor").HasKey(x => x.IdExpositor);
        modelBuilder.Entity<EventoParalelo>().ToTable("EventosParalelos").HasKey(x => x.IdEvento);
        modelBuilder.Entity<EventoExpositor>().ToTable("EventoExpositor").HasKey(x => new { x.IdEvento, x.IdExpositor });
        modelBuilder.Entity<Asistente>().ToTable("Asistentes").HasKey(x => x.IdAsistente);
        modelBuilder.Entity<TipoAcreditacion>().ToTable("TipoAcreditacion").HasKey(x => x.IdTipoAcreditacion);
        modelBuilder.Entity<Acreditacion>().ToTable("Acreditacion").HasKey(x => x.IdAcreditacion);
        modelBuilder.Entity<Alojamiento>().ToTable("Alojamiento").HasKey(x => x.IdAlojamiento);
        modelBuilder.Entity<Traslado>().ToTable("Traslados").HasKey(x => x.IdTraslado);
        modelBuilder.Entity<Compra>().ToTable("Compra").HasKey(x => x.IdCompra);
        modelBuilder.Entity<Tarifa>().ToTable("Tarifas").HasKey(x => x.IdTarifa);
        modelBuilder.Entity<Factura>().ToTable("Factura").HasKey(x => x.IdFactura);
        modelBuilder.Entity<TipoAbono>().ToTable("TipoAbono").HasKey(x => x.IdTipoAbono);
        modelBuilder.Entity<Abono>().ToTable("Abono").HasKey(x => x.IdAbono);
        modelBuilder.Entity<AbonoProyeccion>().ToTable("AbonoProyeccion").HasKey(x => new { x.IdAbono, x.IdProyeccion });
        modelBuilder.Entity<EntradaIndividual>().ToTable("EntradasIndividuales").HasKey(x => x.IdEntrada);
        modelBuilder.Entity<AsistenciaProyeccion>().ToTable("AsistenciaProyeccion").HasKey(x => x.IdAsistencia);
        modelBuilder.Entity<Jurado>().ToTable("Jurado").HasKey(x => x.IdJurado);
        modelBuilder.Entity<CategoriaCompeticion>().ToTable("CategoriasCompeticion").HasKey(x => x.IdCategoria);
        modelBuilder.Entity<CategoriaJurado>().ToTable("CategoriaJurado").HasKey(x => new { x.IdCategoria, x.IdJurado });
        modelBuilder.Entity<PeliculaCompite>().ToTable("PeliculaCompite").HasKey(x => x.IdCompetencia);
        modelBuilder.Entity<Evaluacion>().ToTable("Evaluacion").HasKey(x => x.IdEvaluacion);
        modelBuilder.Entity<Premio>().ToTable("Premio").HasKey(x => x.IdPremio);

        modelBuilder.Entity<Patrocinio>().Property(x => x.Monto).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<EventoParalelo>().Property(x => x.Costo).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Tarifa>().Property(x => x.Precio).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Factura>().Property(x => x.Monto).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<TipoAbono>().Property(x => x.PrecioBase).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Abono>().Property(x => x.PrecioAplicado).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<EntradaIndividual>().Property(x => x.PrecioAplicado).HasColumnType("decimal(10,2)");
        modelBuilder.Entity<Evaluacion>().Property(x => x.Puntuacion).HasColumnType("decimal(4,2)");
    }
}
