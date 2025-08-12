using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

// Universidad Estatal a Distancia (UNED)
// II Cuatrimestre 2025
// Programación Avanzada con C# - Proyecto 2
// Jorge Luis Arias Melendez
// Descripción del archivo: Define el sobre de SOLICITUD para mensajes TCP en JSON
// (comando + datos + correlationId) y utilidades para trabajar con System.Text.Json.


namespace Entregas.Entidades
{
    public class MensajeSolicitud
    {
        // Comando que el cliente solicita ejecutar ("ping", "listar_articulos_activos")
        public string Comando { get; set; } = string.Empty;

        // Id de correlación opcional para emparejar solicitud/respuesta en el cliente.
        public string? CorrelationId { get; set; }

        // Carga útil arbitraria. Se mantiene como JsonElement? para ser flexible y eficiente.
        public JsonElement? Datos { get; set; }

        // Constructor vacío
        public MensajeSolicitud() { }

        // Constructor práctico para crear la solicitud con datos tipados
        public MensajeSolicitud(string comando, object? datos = null, string? correlationId = null)
        {
            Comando = comando ?? string.Empty;
            CorrelationId = correlationId;

            if (datos != null)
                Datos = JsonSerializer.SerializeToElement(datos, DefaultJsonOptions);
        }

        // Serializa a una cadena JSON (sin salto de línea).
        public string ToJson() => JsonSerializer.Serialize(this, DefaultJsonOptions);

        // Serializa a JSON y agrega un \n para usarlo como delimitador de mensajes en el socket.
        public string ToJsonLine() => ToJson() + "\n";

        // Deserializa desde JSON a MensajeSolicitud.
        public static MensajeSolicitud FromJson(string json)
            => JsonSerializer.Deserialize<MensajeSolicitud>(json, DefaultJsonOptions)!
               ?? throw new InvalidOperationException("No se pudo deserializar la solicitud.");

        // Reemplaza la propiedad Datos con un objeto tipado (lo serializa a JsonElement).
        public MensajeSolicitud WithDatos(object? datos)
        {
            Datos = datos == null
                ? (JsonElement?)null
                : JsonSerializer.SerializeToElement(datos, DefaultJsonOptions);
            return this;
        }

        // deserializar 'Datos' al tipo T. Devuelve false si no es posible.
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

        // Deserializa 'Datos' al tipo T o lanza excepción si no existe o el formato es inválido.
        public T GetDatos<T>()
        {
            if (Datos is null)
                throw new InvalidOperationException("La solicitud no contiene 'datos'.");

            var obj = Datos.Value.Deserialize<T>(DefaultJsonOptions);
            if (obj is null)
                throw new InvalidOperationException("El contenido de 'datos' no coincide con el tipo esperado.");

            return obj;
        }

        // Indica si 'Datos' (cuando es objeto) contiene una propiedad con el nombre indicado.
        public bool HasDato(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName)) return false;
            if (Datos is null || Datos.Value.ValueKind != JsonValueKind.Object) return false;

            return Datos.Value.TryGetProperty(propertyName, out _);
        }

        // Intenta obtener una propiedad específica dentro de 'Datos' y convertirla a T.
        public bool TryGetDato<T>(string propertyName, out T value)
        {
            value = default!;
            if (string.IsNullOrWhiteSpace(propertyName)) return false;
            if (Datos is null || Datos.Value.ValueKind != JsonValueKind.Object) return false;
            if (!Datos.Value.TryGetProperty(propertyName, out var prop)) return false;

            try
            {
                value = prop.Deserialize<T>(DefaultJsonOptions)!;
                return true;
            }
            catch
            {
                value = default!;
                return false;
            }
        }



        // Fábricas de conveniencia para comandos comunes.
        public static MensajeSolicitud Ping(string? correlationId = null)
            => new MensajeSolicitud("ping", null, correlationId);

        public static MensajeSolicitud ConDatos(string comando, object datos, string? correlationId = null)
            => new MensajeSolicitud(comando, datos, correlationId);

        // Opciones JSON por defecto para garantizar camelCase y compatibilidad con el cliente.
        public static readonly JsonSerializerOptions DefaultJsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
}

