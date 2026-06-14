# FestCineApi Completo - Backend actualizado

Backend ASP.NET Core Web API conectado a SQL Server para la base de datos FestCine.

## Cambios aplicados en esta version

Esta version fue ajustada para el script SQL corregido e integrado recibido en el archivo `Pasted text.txt`:

- `EventosParalelos` ahora incluye `IdEdicion`.
- Se agrego el modelo y controlador de `SedeEdicion`.
- El informe financiero ahora devuelve `TipoVenta`, `SubtipoVenta`, `TipoTarifa`, `CantidadVentas` y `TotalRecaudado`.
- Agenda soporta insercion y actualizacion de proyecciones.
- Agenda soporta insercion y actualizacion de eventos paralelos.
- El backend queda preparado para los triggers `TR_ControlAgendaProyecciones`, `TR_ControlAgendaEventos`, `TR_ControlAsistenciaProyeccion` y `TR_ValidarFacturaMonto`.
- `Program.cs` queda configurado para Swagger en desarrollo sin redireccion HTTPS obligatoria.
- `appsettings.json` apunta a `LAPTOP-FGOVNBET` con Windows Authentication.

## Ejecutar

```bash
dotnet restore
dotnet run
```

Swagger:

```text
http://localhost:5075/swagger
```

## Endpoints importantes

- `GET /api/health`
- `GET /api/ediciones`
- `GET /api/catalogos/sedes/ED003`
- `GET /api/catalogos/salas/ED003`
- `GET /api/catalogos/eventos/ED003`
- `GET /api/reportes/financiero/ED003`
- `POST /api/taquilla/comprar-entrada`
- `POST /api/abonos/vender`
- `POST /api/agenda/proyecciones`
- `PUT /api/agenda/proyecciones/{idProyeccion}`
- `POST /api/agenda/eventos`
- `PUT /api/agenda/eventos/{idEvento}`

## Importante

No ejecutar migraciones de Entity Framework. La base se crea desde el script SQL.


## Actualización por PK compuesta

Esta versión fue ajustada para el script SQL donde `SedeEdicion` y `ParticipacionPelicula` son entidades asociativas puras:

- `SedeEdicion` usa PK compuesta: `(IdSede, IdEdicion)`.
- `ParticipacionPelicula` usa PK compuesta: `(IdPersonal, IdPelicula, IdRol)`.
- Se eliminaron del modelo C# los campos `IdSedeEdicion` e `IdParticipacion`.
- Los controladores de esas tablas ahora reciben la llave compuesta por URL.

Ejemplos:

```http
DELETE /api/sede-ediciones/SE001/ED003
DELETE /api/participaciones-pelicula/PC001/PL001/RC001
```
