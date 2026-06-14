namespace FestCineApi.DTOs;

public class EdicionDto
{
    public string IdEdicion { get; set; } = string.Empty;
    public string NombreEdicion { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public string EstadoEdicion { get; set; } = string.Empty;
}

public class PeliculaCatalogoDto
{
    public string IdPelicula { get; set; } = string.Empty;
    public string IdPeliculaEdicion { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int Duracion { get; set; }
    public string EstadoFestival { get; set; } = string.Empty;
}

public class ProyeccionCatalogoDto
{
    public string IdProyeccion { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; }
    public bool TieneQA { get; set; }
    public string IdSala { get; set; } = string.Empty;
    public string NombreSala { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public string TituloPelicula { get; set; } = string.Empty;
}

public class AsistenteCatalogoDto
{
    public string IdAsistente { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
}

public class DashboardDto
{
    public string IdEdicion { get; set; } = string.Empty;
    public int Peliculas { get; set; }
    public int Proyecciones { get; set; }
    public int Asistentes { get; set; }
    public int EntradasVendidas { get; set; }
    public int AbonosVendidos { get; set; }
    public decimal TotalRecaudado { get; set; }
}

public class RankingPeliculaDto
{
    public string IdPelicula { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int CantidadProyecciones { get; set; }
    public int CapacidadTotal { get; set; }
    public int AsistentesReales { get; set; }
    public decimal PorcentajeOcupacion { get; set; }
}

public class ActaPremiacionDto
{
    public string IdCategoria { get; set; } = string.Empty;
    public string NombreCategoria { get; set; } = string.Empty;
    public string NombrePremio { get; set; } = string.Empty;
    public string IdPelicula { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public int CantidadEvaluaciones { get; set; }
    public decimal PromedioVotacion { get; set; }
}

public class InformeFinancieroDto
{
    public string TipoVenta { get; set; } = string.Empty;
    public string SubtipoVenta { get; set; } = string.Empty;
    public string TipoTarifa { get; set; } = string.Empty;
    public int CantidadVentas { get; set; }
    public decimal TotalRecaudado { get; set; }
}

public class CompraEntradaRequest
{
    public string IdAsistente { get; set; } = string.Empty;
    public string IdProyeccion { get; set; } = string.Empty;
    public string IdTarifa { get; set; } = string.Empty;
    public string MetodoPago { get; set; } = string.Empty;
    public string? Nit { get; set; }
    public string NombreCompra { get; set; } = string.Empty;
    public int? NroAsiento { get; set; }
}

public class CompraEntradaResponse
{
    public string IdCompra { get; set; } = string.Empty;
    public string IdEntrada { get; set; } = string.Empty;
    public string IdFactura { get; set; } = string.Empty;
    public string CodigoEntrada { get; set; } = string.Empty;
    public decimal MontoPagado { get; set; }
}

public class VentaAbonoRequest
{
    public string IdAsistente { get; set; } = string.Empty;
    public string IdTipoAbono { get; set; } = string.Empty;
    public string IdTarifa { get; set; } = string.Empty;
    public string MetodoPago { get; set; } = string.Empty;
    public string? Nit { get; set; }
    public string NombreCompra { get; set; } = string.Empty;
    public bool PagoAprobado { get; set; }
}

public class VentaAbonoResponse
{
    public string IdCompra { get; set; } = string.Empty;
    public string IdAbono { get; set; } = string.Empty;
    public string IdFactura { get; set; } = string.Empty;
    public string CodigoAbono { get; set; } = string.Empty;
    public decimal MontoPagado { get; set; }
}

public class CrearProyeccionRequest
{
    public string IdProyeccion { get; set; } = string.Empty;
    public DateTime FechaHoraInicio { get; set; }
    public bool TieneQA { get; set; }
    public string IdSala { get; set; } = string.Empty;
    public string IdPeliculaEdicion { get; set; } = string.Empty;
}

public class CrearProyeccionResponse
{
    public string IdProyeccion { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
}


public class CrearEventoRequest
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

public class CrearEventoResponse
{
    public string IdEvento { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
}
