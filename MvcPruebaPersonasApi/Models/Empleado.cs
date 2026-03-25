using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace MvcPruebaPersonasApi.Models
{
    public class Empleado
    {
        [JsonProperty("idEmpleado")]
        public int IdEmpleado { get; set; }
        [JsonProperty("apellido")]
        public string Apellido { get; set; }
        [JsonProperty("oficio")]
        public string Oficio { get; set; }
        [JsonProperty("salario")]
        public int Salario { get; set; }
        [JsonProperty("idDepartamento")]
        public int IdDepartamento { get; set; }
    }
}
