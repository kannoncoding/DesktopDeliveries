using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Entregas.Entidades
{
    public class MensajeRespuesta
    {
        // Id de correlación para emparejar solicitud/respuesta.
        public string? CorrelationId { get; set; }

        // Indica si la operación solicitada fue exitosa.
        public bool Exito { get; set; }

        // Mensaje de error cuando Exito == false.
        public string? Error { get; set; }

        // Carga útil arbitraria. Se mantiene como JsonElement? para flexibilidad/eficiencia.
        public JsonElement? Datos { get; set; }

        // Propiedad de conveniencia.
        public bool TieneError => !Exito || !string.IsNullOrWhiteSpace(Error);

        public MensajeRespuesta() { }

        public MensajeRespuesta(bool exito, object? datos = null, string? error = null, string? correlationId = null)
        {
            Exito = exito;
            Error = error;
            CorrelationId = correlationId;

            if (datos != null)
                Datos = JsonSerializer.SerializeToElement(datos, DefaultJsonOptions);
        }

        // Fábricas comunes
        public static MensajeRespuesta Ok(object? datos = null, string? correlationId = null)
            => new MensajeRespuesta(true, datos, null, correlationId);

        public static MensajeRespuesta Fail(string error, string? correlationId = null, object? datos = null)
            => new MensajeRespuesta(false, datos, error, correlationId);

        // Serialización
        public string ToJson() => JsonSerializer.Serialize(this, DefaultJsonOptions);

        public string ToJsonLine() => ToJson() + "\n";

        public static MensajeRespuesta FromJson(string json)
            => JsonSerializer.Deserialize<MensajeRespuesta>(json, DefaultJsonOptions)!
               ?? throw new InvalidOperationException("No se pudo deserializar la respuesta.");

        // Mutadores fluidos
        public MensajeRespuesta WithDatos(object? datos)
        {
            Datos = datos == null
                ? (JsonElement?)null
                : JsonSerializer.SerializeToElement(datos, DefaultJsonOptions);
            return this;
        }

        public MensajeRespuesta WithCorrelation(string? correlationId)
        {
            CorrelationId = correlationId;
            return this;
        }

        public MensajeRespuesta SetOk()
        {
            Exito = true;
            Error = null;
            return this;
        }

        public MensajeRespuesta SetError(string error)
        {
            Exito = false;
            Error = error;
            return this;
        }

        // Lectura tipada del payload completo
        public bool TryGetDatos<T>(out T? value)
        {
            value = default;
            if (Datos is null) return false;

            try
            {
                value = Datos.Value.Deserialize<T>(DefaultJsonOptions);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T GetDatos<T>()
        {
            if (Datos is null)
                throw new InvalidOperationException("La respuesta no contiene 'datos'.");

            var obj = Datos.Value.Deserialize<T>(DefaultJsonOptions);
            if (obj is null)
                throw new InvalidOperationException("El contenido de 'datos' no coincide con el tipo esperado.");

            return obj;
        }

        // Acceso a propiedades dentro del payload cuando es objeto JSON
        public bool HasDato(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return false;
            if (Datos is null || Datos.Value.ValueKind != JsonValueKind.Object) return false;

            return Datos.Value.TryGetProperty(propertyName, out _);
        }

        public bool TryGetDato<T>(string propertyName, out T? value)
        {
            value = default;

            if (string.IsNullOrWhiteSpace(propertyName)) return false;
            if (Datos is null || Datos.Value.ValueKind != JsonValueKind.Object) return false;

            if (!Datos.Value.TryGetProperty(propertyName, out var prop)) return false;

            try
            {
                value = prop.Deserialize<T>(DefaultJsonOptions);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Opciones JSON por defecto (camelCase, sin identación, encoder permisivo para sockets).
        public static readonly JsonSerializerOptions DefaultJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
}
