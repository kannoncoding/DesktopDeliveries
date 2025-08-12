using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Threading;

namespace Entregas.Entidades
{
    public static class JsonMensajeria
    {
        // Opciones JSON consistentes (camelCase, sin identación, encoder permisivo).
        public static readonly JsonSerializerOptions Opciones = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        // ---------- Serialización / Deserialización de sobres ----------

        public static string SerializarSolicitud(MensajeSolicitud req)
            => JsonSerializer.Serialize(req, Opciones);

        public static string SerializarSolicitudLinea(MensajeSolicitud req)
            => AsegurarLinea(SerializarSolicitud(req));

        public static MensajeSolicitud DeserializarSolicitud(string json)
            => JsonSerializer.Deserialize<MensajeSolicitud>(json, Opciones)!
               ?? throw new InvalidOperationException("No se pudo deserializar la solicitud.");

        public static bool TryDeserializarSolicitud(string json, out MensajeSolicitud? req)
        {
            try
            {
                req = JsonSerializer.Deserialize<MensajeSolicitud>(json, Opciones);
                return req != null;
            }
            catch
            {
                req = null;
                return false;
            }
        }

        public static string SerializarRespuesta(MensajeRespuesta res)
            => JsonSerializer.Serialize(res, Opciones);

        public static string SerializarRespuestaLinea(MensajeRespuesta res)
            => AsegurarLinea(SerializarRespuesta(res));

        public static MensajeRespuesta DeserializarRespuesta(string json)
            => JsonSerializer.Deserialize<MensajeRespuesta>(json, Opciones)!
               ?? throw new InvalidOperationException("No se pudo deserializar la respuesta.");

        public static bool TryDeserializarRespuesta(string json, out MensajeRespuesta? res)
        {
            try
            {
                res = JsonSerializer.Deserialize<MensajeRespuesta>(json, Opciones);
                return res != null;
            }
            catch
            {
                res = null;
                return false;
            }
        }

        // ---------- Helpers genéricos para datos (payload) ----------

        public static JsonElement SerializarDatos<T>(T dato)
            => JsonSerializer.SerializeToElement(dato, Opciones);

        public static T DeserializarDatos<T>(JsonElement? datos)
        {
            if (datos is null)
                throw new InvalidOperationException("El campo 'datos' es nulo.");

            var obj = datos.Value.Deserialize<T>(Opciones);
            if (obj is null)
                throw new InvalidOperationException("No se pudo convertir 'datos' al tipo solicitado.");

            return obj;
        }

        public static bool TryDeserializarDatos<T>(JsonElement? datos, out T? value)
        {
            value = default;
            if (datos is null) return false;

            try
            {
                value = datos.Value.Deserialize<T>(Opciones);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        // ---------- Framing por línea (sockets) ----------

        public static string AsegurarLinea(string s)
            => s.EndsWith("\n") ? s : s + "\n";

        // Crea un lector UTF-8 sin BOM, - ReadLine() por sockets.
        public static StreamReader CrearReader(NetworkStream stream)
            => new StreamReader(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);

        // Crea un escritor UTF-8 sin BOM, AutoFlush = true para enviar inmediatamente.
        public static StreamWriter CrearWriter(NetworkStream stream)
        {
            var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), bufferSize: 1024, leaveOpen: true)
            {
                AutoFlush = true
            };
            return writer;
        }

        // Escribe una línea de manera asíncrona.
        public static Task EscribirLineaAsync(TextWriter writer, string contenido, CancellationToken ct = default)
            => writer.WriteAsync(AsegurarLinea(contenido).AsMemory(), ct).AsTask();

        // Leer línea asíncronamente, null si el stream se cierra.
        public static Task<string?> LeerLineaAsync(TextReader reader, CancellationToken ct = default)
            => reader.ReadLineAsync(ct).AsTask();

        // Atajos para escribir sobres completos.
        public static Task EscribirSolicitudAsync(StreamWriter writer, MensajeSolicitud req, CancellationToken ct = default)
            => EscribirLineaAsync(writer, SerializarSolicitud(req), ct);

        public static Task EscribirRespuestaAsync(StreamWriter writer, MensajeRespuesta res, CancellationToken ct = default)
            => EscribirLineaAsync(writer, SerializarRespuesta(res), ct);

        // ---------- Helpers de conveniencia para endpoints ----------

        public static MensajeSolicitud NuevaSolicitud(string comando, object? datos = null, string? correlationId = null)
        {
            var req = new MensajeSolicitud
            {
                Comando = comando ?? string.Empty,
                CorrelationId = correlationId
            };
            if (datos != null)
                req.Datos = SerializarDatos(datos);
            return req;
        }

        public static MensajeRespuesta Ok(object? datos = null, string? correlationId = null)
        {
            var res = new MensajeRespuesta
            {
                Exito = true,
                Error = null,
                CorrelationId = correlationId
            };
            if (datos != null)
                res.Datos = SerializarDatos(datos);
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
            if (datos != null)
                res.Datos = SerializarDatos(datos);
            return res;
        }
    }
}
