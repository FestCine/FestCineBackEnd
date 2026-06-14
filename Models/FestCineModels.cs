namespace FestCineApi.Models;

public class Persona
{
    public string IdPersona { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string? Telefono { get; set; }
}

public class Edicion
{
    public string IdEdicion { get; set; } = string.Empty;
    public string NombreEdicion { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string EstadoEdicion { get; set; } = string.Empty;
}

public class Pelicula
{
    public string IdPelicula { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int AnioProduccion { get; set; }
    public int Duracion { get; set; }
    public string PaisOrigen { get; set; } = string.Empty;
    public string? Sinopsis { get; set; }
    public string? ClasEdad { get; set; }
    public string FormatoProyeccion { get; set; } = string.Empty;
}

public class PeliculaEdicion
{
    public string IdPeliculaEdicion { get; set; } = string.Empty;
    public string IdPelicula { get; set; } = string.Empty;
    public string IdEdicion { get; set; } = string.Empty;
    public string EstadoFestival { get; set; } = string.Empty;
}

public class Genero
{
    public string IdGenero { get; set; } = string.Empty;
    public string NombreGenero { get; set; } = string.Empty;
}

public class PeliculaGenero
{
    public string IdPelicula { get; set; } = string.Empty;
    public string IdGenero { get; set; } = string.Empty;
}

public class PersonalCinematografico
{
    public string IdPersonal { get; set; } = string.Empty;
    public string? Biografia { get; set; }
    public string? Pais { get; set; }
    public string IdPersona { get; set; } = string.Empty;
}

public class RolCinematografico
{
    public string IdRol { get; set; } = string.Empty;
    public string NombreRol { get; set; } = string.Empty;
}

public class ParticipacionPelicula
{
    public string IdPersonal { get; set; } = string.Empty;
    public string IdPelicula { get; set; } = string.Empty;
    public string IdRol { get; set; } = string.Empty;
}

public class Patrocinador
{
    public string IdPatrocinador { get; set; } = string.Empty;
    public string NombrePatrocinador { get; set; } = string.Empty;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
}

public class Patrocinio
{
    public string IdPatrocinio { get; set; } = string.Empty;
    public string IdPatrocinador { get; set; } = string.Empty;
    public string IdEdicion { get; set; } = string.Empty;
    public string TipoAportacion { get; set; } = string.Empty;
    public decimal? Monto { get; set; }
    public string? DescripcionAportacion { get; set; }
}

public class Sede
{
    public string IdSede { get; set; } = string.Empty;
    public string NombreSede { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string? Ciudad { get; set; }
}

public class SedeEdicion
{
    public string IdSede { get; set; } = string.Empty;
    public string IdEdicion { get; set; } = string.Empty;
}

public class Sala
{
    public string IdSala { get; set; } = string.Empty;
    public int NroSala { get; set; }
    public string NombreSala { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public string IdSede { get; set; } = string.Empty;
}

public class Proyeccion
{
    public string IdProyeccion { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; }
    public bool TieneQA { get; set; }
    public string IdSala { get; set; } = string.Empty;
    public string IdPeliculaEdicion { get; set; } = string.Empty;
}

public class Expositor
{
    public string IdExpositor { get; set; } = string.Empty;
    public string TemaExposicion { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Biografia { get; set; }
    public string Pais { get; set; } = string.Empty;
    public string IdPersona { get; set; } = string.Empty;
}

public class EventoParalelo
{
    public string IdEvento { get; set; } = string.Empty;
    public string NombreEvento { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int Aforo { get; set; }
    public decimal Costo { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public int DuracionMinutos { get; set; }
    public string IdEdicion { get; set; } = string.Empty;
    public string IdSala { get; set; } = string.Empty;
}

public class EventoExpositor
{
    public string IdEvento { get; set; } = string.Empty;
    public string IdExpositor { get; set; } = string.Empty;
}

public class Asistente
{
    public string IdAsistente { get; set; } = string.Empty;
    public string EstadoAsistencia { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
    public string IdEdicion { get; set; } = string.Empty;
    public string IdPersona { get; set; } = string.Empty;
}

public class TipoAcreditacion
{
    public string IdTipoAcreditacion { get; set; } = string.Empty;
    public string NombreTipo { get; set; } = string.Empty;
}

public class Acreditacion
{
    public string IdAcreditacion { get; set; } = string.Empty;
    public string IdAsistente { get; set; } = string.Empty;
    public string IdTipoAcreditacion { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }
    public string EstadoAcreditacion { get; set; } = string.Empty;
}

public class Alojamiento
{
    public string IdAlojamiento { get; set; } = string.Empty;
    public string NombreAlojamiento { get; set; } = string.Empty;
    public string Habitacion { get; set; } = string.Empty;
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public string IdAsistente { get; set; } = string.Empty;
}

public class Traslado
{
    public string IdTraslado { get; set; } = string.Empty;
    public string UbiPartida { get; set; } = string.Empty;
    public string UbiDestino { get; set; } = string.Empty;
    public string TipoTransporte { get; set; } = string.Empty;
    public DateTime FechaHoraTraslado { get; set; }
    public string? Itinerario { get; set; }
    public string IdAsistente { get; set; } = string.Empty;
}

public class Compra
{
    public string IdCompra { get; set; } = string.Empty;
    public DateTime FechaHoraCompra { get; set; }
    public string MetodoPago { get; set; } = string.Empty;
    public string IdEdicion { get; set; } = string.Empty;
}

public class Tarifa
{
    public string IdTarifa { get; set; } = string.Empty;
    public string TipoTarifa { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }
}

public class Factura
{
    public string IdFactura { get; set; } = string.Empty;
    public string? NIT { get; set; }
    public string? NombreCompra { get; set; }
    public decimal Monto { get; set; }
    public string IdCompra { get; set; } = string.Empty;
}

public class TipoAbono
{
    public string IdTipoAbono { get; set; } = string.Empty;
    public string NombreTipoAbono { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal PrecioBase { get; set; }
}

public class Abono
{
    public string IdAbono { get; set; } = string.Empty;
    public string CodigoAbono { get; set; } = string.Empty;
    public decimal PrecioAplicado { get; set; }
    public string EstadoAbono { get; set; } = string.Empty;
    public string IdCompra { get; set; } = string.Empty;
    public string IdAsistente { get; set; } = string.Empty;
    public string IdTipoAbono { get; set; } = string.Empty;
    public string IdTarifa { get; set; } = string.Empty;
}

public class AbonoProyeccion
{
    public string IdAbono { get; set; } = string.Empty;
    public string IdProyeccion { get; set; } = string.Empty;
}

public class EntradaIndividual
{
    public string IdEntrada { get; set; } = string.Empty;
    public string CodigoEntrada { get; set; } = string.Empty;
    public int? NroAsiento { get; set; }
    public decimal PrecioAplicado { get; set; }
    public string IdCompra { get; set; } = string.Empty;
    public string? IdProyeccion { get; set; }
    public string? IdEvento { get; set; }
    public string IdAsistente { get; set; } = string.Empty;
    public string IdTarifa { get; set; } = string.Empty;
}

public class AsistenciaProyeccion
{
    public string IdAsistencia { get; set; } = string.Empty;
    public DateTime FechaHoraControl { get; set; }
    public bool Asistio { get; set; }
    public string IdProyeccion { get; set; } = string.Empty;
    public string IdAsistente { get; set; } = string.Empty;
    public string? IdEntrada { get; set; }
    public string? IdAbono { get; set; }
}

public class Jurado
{
    public string IdJurado { get; set; } = string.Empty;
    public string EstadoAsistencia { get; set; } = string.Empty;
    public string? Especialidad { get; set; }
    public string? TipoJurado { get; set; }
    public string IdPersona { get; set; } = string.Empty;
}

public class CategoriaCompeticion
{
    public string IdCategoria { get; set; } = string.Empty;
    public string NombreCategoria { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string IdEdicion { get; set; } = string.Empty;
}

public class CategoriaJurado
{
    public string IdCategoria { get; set; } = string.Empty;
    public string IdJurado { get; set; } = string.Empty;
}

public class PeliculaCompite
{
    public string IdCompetencia { get; set; } = string.Empty;
    public string? EstadoParticipacion { get; set; }
    public DateTime? FechaParticipacion { get; set; }
    public string IdCategoria { get; set; } = string.Empty;
    public string IdPeliculaEdicion { get; set; } = string.Empty;
}

public class Evaluacion
{
    public string IdEvaluacion { get; set; } = string.Empty;
    public decimal Puntuacion { get; set; }
    public string? Comentario { get; set; }
    public DateTime FechaEvaluacion { get; set; }
    public string IdJurado { get; set; } = string.Empty;
    public string IdCategoria { get; set; } = string.Empty;
    public string IdCompetencia { get; set; } = string.Empty;
}

public class Premio
{
    public string IdPremio { get; set; } = string.Empty;
    public string NombrePremio { get; set; } = string.Empty;
    public DateTime FechaPremiacion { get; set; }
    public string IdCompetencia { get; set; } = string.Empty;
    public string IdCategoria { get; set; } = string.Empty;
}
