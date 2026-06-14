using FestCineApi.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FestCineApi.Services;

public class FestCineService
{
    private readonly string _connectionString;

    public FestCineService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("FestCineConnection")
            ?? throw new InvalidOperationException("No se encontro la cadena de conexion FestCineConnection.");
    }

    private SqlConnection CreateConnection() => new(_connectionString);

    public async Task<List<EdicionDto>> ListarEdicionesAsync()
    {
        var result = new List<EdicionDto>();
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_ListarEdiciones", cn) { CommandType = CommandType.StoredProcedure };
        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        while (await rd.ReadAsync())
        {
            result.Add(new EdicionDto
            {
                IdEdicion = rd["IdEdicion"].ToString()!,
                NombreEdicion = rd["NombreEdicion"].ToString()!,
                FechaInicio = Convert.ToDateTime(rd["FechaInicio"]),
                FechaFin = Convert.ToDateTime(rd["FechaFin"]),
                EstadoEdicion = rd["EstadoEdicion"].ToString()!
            });
        }
        return result;
    }

    public async Task<List<RankingPeliculaDto>> RankingAsync(string idEdicion)
    {
        var result = new List<RankingPeliculaDto>();
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_RankingPeliculasPorEdicion", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@IdEdicion", idEdicion);
        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        while (await rd.ReadAsync())
        {
            result.Add(new RankingPeliculaDto
            {
                IdPelicula = rd["IdPelicula"].ToString()!,
                Titulo = rd["Titulo"].ToString()!,
                CantidadProyecciones = Convert.ToInt32(rd["CantidadProyecciones"]),
                CapacidadTotal = Convert.ToInt32(rd["CapacidadTotal"]),
                AsistentesReales = Convert.ToInt32(rd["AsistentesReales"]),
                PorcentajeOcupacion = Convert.ToDecimal(rd["PorcentajeOcupacion"])
            });
        }
        return result;
    }

    public async Task<List<ActaPremiacionDto>> ActaPremiacionAsync(string idEdicion)
    {
        var result = new List<ActaPremiacionDto>();
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_ActaPremiacionPorEdicion", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@IdEdicion", idEdicion);
        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        while (await rd.ReadAsync())
        {
            result.Add(new ActaPremiacionDto
            {
                IdCategoria = rd["IdCategoria"].ToString()!,
                NombreCategoria = rd["NombreCategoria"].ToString()!,
                NombrePremio = rd["NombrePremio"].ToString()!,
                IdPelicula = rd["IdPelicula"].ToString()!,
                Titulo = rd["Titulo"].ToString()!,
                CantidadEvaluaciones = Convert.ToInt32(rd["CantidadEvaluaciones"]),
                PromedioVotacion = Convert.ToDecimal(rd["PromedioVotacion"])
            });
        }
        return result;
    }

    public async Task<List<InformeFinancieroDto>> InformeFinancieroAsync(string idEdicion)
    {
        var result = new List<InformeFinancieroDto>();
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_InformeFinancieroPorEdicion", cn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@IdEdicion", idEdicion);
        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        while (await rd.ReadAsync())
        {
            result.Add(new InformeFinancieroDto
            {
                TipoVenta = rd["TipoVenta"].ToString()!,
                SubtipoVenta = rd["SubtipoVenta"].ToString()!,
                TipoTarifa = rd["TipoTarifa"].ToString()!,
                CantidadVentas = Convert.ToInt32(rd["CantidadVentas"]),
                TotalRecaudado = Convert.ToDecimal(rd["TotalRecaudado"])
            });
        }
        return result;
    }

    public async Task<CompraEntradaResponse?> ComprarEntradaAsync(CompraEntradaRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_ComprarEntrada", cn) { CommandType = CommandType.StoredProcedure };

        cmd.Parameters.AddWithValue("@IdAsistente", request.IdAsistente);
        cmd.Parameters.AddWithValue("@IdProyeccion", request.IdProyeccion);
        cmd.Parameters.AddWithValue("@IdTarifa", request.IdTarifa);
        cmd.Parameters.AddWithValue("@MetodoPago", request.MetodoPago);
        cmd.Parameters.AddWithValue("@NIT", (object?)request.Nit ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@NombreCompra", request.NombreCompra);
        cmd.Parameters.AddWithValue("@NroAsiento", (object?)request.NroAsiento ?? DBNull.Value);

        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        if (!await rd.ReadAsync()) return null;

        return new CompraEntradaResponse
        {
            IdCompra = rd["IdCompra"].ToString()!,
            IdEntrada = rd["IdEntrada"].ToString()!,
            IdFactura = rd["IdFactura"].ToString()!,
            CodigoEntrada = rd["CodigoEntrada"].ToString()!,
            MontoPagado = Convert.ToDecimal(rd["MontoPagado"])
        };
    }

    public async Task<VentaAbonoResponse?> VenderAbonoAsync(VentaAbonoRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand("SP_VenderAbono", cn) { CommandType = CommandType.StoredProcedure };

        cmd.Parameters.AddWithValue("@IdAsistente", request.IdAsistente);
        cmd.Parameters.AddWithValue("@IdTipoAbono", request.IdTipoAbono);
        cmd.Parameters.AddWithValue("@IdTarifa", request.IdTarifa);
        cmd.Parameters.AddWithValue("@MetodoPago", request.MetodoPago);
        cmd.Parameters.AddWithValue("@NIT", (object?)request.Nit ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@NombreCompra", request.NombreCompra);
        cmd.Parameters.AddWithValue("@PagoAprobado", request.PagoAprobado);

        await cn.OpenAsync();
        await using var rd = await cmd.ExecuteReaderAsync();
        if (!await rd.ReadAsync()) return null;

        return new VentaAbonoResponse
        {
            IdCompra = rd["IdCompra"].ToString()!,
            IdAbono = rd["IdAbono"].ToString()!,
            IdFactura = rd["IdFactura"].ToString()!,
            CodigoAbono = rd["CodigoAbono"].ToString()!,
            MontoPagado = Convert.ToDecimal(rd["MontoPagado"])
        };
    }

    public async Task CrearProyeccionAsync(CrearProyeccionRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand(@"
            INSERT INTO Proyecciones
            (
                IdProyeccion,
                FechaHoraInicio,
                TieneQA,
                IdSala,
                IdPeliculaEdicion
            )
            VALUES
            (
                @IdProyeccion,
                @FechaHoraInicio,
                @TieneQA,
                @IdSala,
                @IdPeliculaEdicion
            );", cn);

        cmd.Parameters.AddWithValue("@IdProyeccion", request.IdProyeccion);
        cmd.Parameters.AddWithValue("@FechaHoraInicio", request.FechaHoraInicio);
        cmd.Parameters.AddWithValue("@TieneQA", request.TieneQA);
        cmd.Parameters.AddWithValue("@IdSala", request.IdSala);
        cmd.Parameters.AddWithValue("@IdPeliculaEdicion", request.IdPeliculaEdicion);

        await cn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task ActualizarProyeccionAsync(string idProyeccion, CrearProyeccionRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand(@"
            UPDATE Proyecciones
            SET
                FechaHoraInicio = @FechaHoraInicio,
                TieneQA = @TieneQA,
                IdSala = @IdSala,
                IdPeliculaEdicion = @IdPeliculaEdicion
            WHERE IdProyeccion = @IdProyeccion;", cn);

        cmd.Parameters.AddWithValue("@IdProyeccion", idProyeccion);
        cmd.Parameters.AddWithValue("@FechaHoraInicio", request.FechaHoraInicio);
        cmd.Parameters.AddWithValue("@TieneQA", request.TieneQA);
        cmd.Parameters.AddWithValue("@IdSala", request.IdSala);
        cmd.Parameters.AddWithValue("@IdPeliculaEdicion", request.IdPeliculaEdicion);

        await cn.OpenAsync();
        var affected = await cmd.ExecuteNonQueryAsync();
        if (affected == 0)
            throw new InvalidOperationException("No existe la proyeccion indicada.");
    }

    public async Task CrearEventoAsync(CrearEventoRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand(@"
            INSERT INTO EventosParalelos
            (
                IdEvento,
                NombreEvento,
                TipoEvento,
                Descripcion,
                Aforo,
                Costo,
                FechaHoraInicio,
                DuracionMinutos,
                IdEdicion,
                IdSala
            )
            VALUES
            (
                @IdEvento,
                @NombreEvento,
                @TipoEvento,
                @Descripcion,
                @Aforo,
                @Costo,
                @FechaHoraInicio,
                @DuracionMinutos,
                @IdEdicion,
                @IdSala
            );", cn);

        cmd.Parameters.AddWithValue("@IdEvento", request.IdEvento);
        cmd.Parameters.AddWithValue("@NombreEvento", request.NombreEvento);
        cmd.Parameters.AddWithValue("@TipoEvento", request.TipoEvento);
        cmd.Parameters.AddWithValue("@Descripcion", (object?)request.Descripcion ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Aforo", request.Aforo);
        cmd.Parameters.AddWithValue("@Costo", request.Costo);
        cmd.Parameters.AddWithValue("@FechaHoraInicio", request.FechaHoraInicio);
        cmd.Parameters.AddWithValue("@DuracionMinutos", request.DuracionMinutos);
        cmd.Parameters.AddWithValue("@IdEdicion", request.IdEdicion);
        cmd.Parameters.AddWithValue("@IdSala", request.IdSala);

        await cn.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
    }

    public async Task ActualizarEventoAsync(string idEvento, CrearEventoRequest request)
    {
        await using var cn = CreateConnection();
        await using var cmd = new SqlCommand(@"
            UPDATE EventosParalelos
            SET
                NombreEvento = @NombreEvento,
                TipoEvento = @TipoEvento,
                Descripcion = @Descripcion,
                Aforo = @Aforo,
                Costo = @Costo,
                FechaHoraInicio = @FechaHoraInicio,
                DuracionMinutos = @DuracionMinutos,
                IdEdicion = @IdEdicion,
                IdSala = @IdSala
            WHERE IdEvento = @IdEvento;", cn);

        cmd.Parameters.AddWithValue("@IdEvento", idEvento);
        cmd.Parameters.AddWithValue("@NombreEvento", request.NombreEvento);
        cmd.Parameters.AddWithValue("@TipoEvento", request.TipoEvento);
        cmd.Parameters.AddWithValue("@Descripcion", (object?)request.Descripcion ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@Aforo", request.Aforo);
        cmd.Parameters.AddWithValue("@Costo", request.Costo);
        cmd.Parameters.AddWithValue("@FechaHoraInicio", request.FechaHoraInicio);
        cmd.Parameters.AddWithValue("@DuracionMinutos", request.DuracionMinutos);
        cmd.Parameters.AddWithValue("@IdEdicion", request.IdEdicion);
        cmd.Parameters.AddWithValue("@IdSala", request.IdSala);

        await cn.OpenAsync();
        var affected = await cmd.ExecuteNonQueryAsync();
        if (affected == 0)
            throw new InvalidOperationException("No existe el evento indicado.");
    }

}
