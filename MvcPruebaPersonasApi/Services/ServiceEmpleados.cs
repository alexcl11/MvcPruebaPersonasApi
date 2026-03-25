using MvcPruebaPersonasApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcPruebaPersonasApi.Services
{
    public class ServiceEmpleados
    {
        private string ApiUrl;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration configuration)
        {
            this.ApiUrl = configuration.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/empleados";
                client.BaseAddress =new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(json);
                    return empleados;

                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Empleado> FindEmpleadoAsync(int idEmpleado)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/empleados/" + idEmpleado;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Empleado empleado = await response.Content.ReadAsAsync<Empleado>();
                    return empleado;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}
