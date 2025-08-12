// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 2
// Jorge Luis Arias Melendez
// Descripción del archivo: Utilidades de mensajería JSON para solicitudes y respuestas TCP.

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Entregas.Entidades
{
    public static class JsonMensajeria
    {
        public static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        // ---------- Solicitudes ----------
        public static string SerializarSolicitud(MensajeSolicitud req)
            => JsonSerializer.Serialize(req, Opciones);

        public static string SerializarSolicitudLinea(MensajeSolicitud req)
            => AsegurarLinea(SerializarSolicitud(req));

        public static MensajeSolicitud DeserializarSolicitud(string json)
            => JsonSerializer.Deserialize<MensajeSolicitud>(json, Opciones)
               ?? throw new InvalidOperationException("No se pudo deserializar la solicitud.");

        public static bool TryDeserializarSolicitud(string json, out MensajeSolicitud? req)
        {
            try { req = JsonSerializer.Deserialize<MensajeSolicitud>(json, Opciones); return req != null; }
            catch { req = null; return false; }
        }

        // ---------- Respuestas ----------
        public static string SerializarRespuesta(MensajeRespuesta res)
            => JsonSerializer.Serialize(res, Opciones);

        public static string SerializarRespuestaLinea(MensajeRespuesta res)
            => AsegurarLinea(SerializarRespuesta(res));

        public static MensajeRespuesta DeserializarRespuesta(string json)
            => JsonSerializer.Deserialize<MensajeRespuesta>(json, Opciones)
               ?? throw new InvalidOperationException("No se pudo deserializar la respuesta.");

        public static bool TryDeserializarRespuesta(string json, out MensajeRespuesta? res)
        {
            try { res = JsonSerializer.Deserialize<MensajeRespuesta>(json, Opciones); return res != null; }
            catch { res = null; return false; }
        }

        // ---------- Payload genérico ----------
        public static JsonElement SerializarDatos<T>(T dato)
            => JsonSerializer.SerializeToElement(dato, Opciones);

        public static T DeserializarDatos<T>(JsonElement? datos)
        {
            if (datos is null) throw new InvalidOperationException("El campo 'datos' es nulo.");
            var obj = datos.Value.Deserialize<T>(Opciones);
            if (obj is null) throw new InvalidOperationException("No se pudo convertir 'datos' al tipo solicitado.");
            return obj;
        }

        public static bool TryDeserializarDatos<T>(JsonElement? datos, out T? value)
        {
            value = default;
            if (datos is null) return false;
            try { value = datos.Value.Deserialize<T>(Opciones); return true; }
            catch { value = default; return false; }
        }

        // ---------- Framing por línea ----------
        public static string AsegurarLinea(string s) => s.EndsWith("\n") ? s : s + "\n";

        public static StreamReader CrearReader(NetworkStream stream)
            => new StreamReader(stream, new UTF8Encoding(false), true, 1024, leaveOpen: true);

        public static StreamWriter CrearWriter(NetworkStream stream)
            => new StreamWriter(stream, new UTF8Encoding(false), 1024, leaveOpen: true) { AutoFlush = true };

        // ¡OJO! Solo existe un par de métodos async; sin .AsTask() y sin duplicados.
        public static async Task EscribirLineaAsync(TextWriter writer, string contenido, CancellationToken ct = default)
        {
            await writer.WriteAsync(AsegurarLinea(contenido));
            await writer.FlushAsync();
        }

        public static async Task<string?> LeerLineaAsync(TextReader reader, CancellationToken ct = default)
        {
            return await reader.ReadLineAsync();
        }

        // Atajos para sobres completos
        public static Task EscribirSolicitudAsync(StreamWriter writer, MensajeSolicitud req, CancellationToken ct = default)
            => EscribirLineaAsync(writer, SerializarSolicitud(req), ct);

        public static Task EscribirRespuestaAsync(StreamWriter writer, MensajeRespuesta res, CancellationToken ct = default)
            => EscribirLineaAsync(writer, SerializarRespuesta(res), ct);

        // Fábricas útiles
        public static MensajeSolicitud NuevaSolicitud(string comando, object? datos = null, string? correlationId = null)
        {
            var req = new MensajeSolicitud { Comando = comando ?? string.Empty, CorrelationId = correlationId };
            if (datos != null) req.Datos = SerializarDatos(datos);
            return req;
        }

        public static MensajeRespuesta Ok(object? datos = null, string? correlationId = null)
        {
            var res = new MensajeRespuesta { Exito = true, Error = null, CorrelationId = correlationId };
            if (datos != null) res.Datos = SerializarDatos(datos);
            return res;
        }

        public static MensajeRespuesta Fail(string error, string? correlationId = null, object? datos = null)
        {
            var res = new MensajeRespuesta
            {
                Exito = false,
                Error = string.IsNullOrWhiteSpace(error) ? "Error no especificado" : error,
                CorrelationId = correlationId
            };
            if (datos != null) res.Datos = SerializarDatos(datos);
            return res;
        }
    }
}
