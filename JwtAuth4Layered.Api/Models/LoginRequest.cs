using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth4Layered.Api.Models
{
    public class LoginRequest
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}