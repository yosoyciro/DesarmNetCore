using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.api.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null) 
        {
            StatusCode = statusCode;
            Mensaje = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int pStatusCode)
        {
            return StatusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "No tiene autorización para este recurso",
                404 => "No se encontró el registro buscado",
                500 => "Se produjo un error en el servidor",
                _ => null
            };
        }
        public int StatusCode { get; set; }
        public string Mensaje { get; set; }
    }
}
