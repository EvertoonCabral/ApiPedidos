using System.Text.Json.Serialization;

namespace ApiControlePedidos.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum StatusPedido
    {

        ABERTO,
        FECHADO,
        CANCELADO

    }
}
