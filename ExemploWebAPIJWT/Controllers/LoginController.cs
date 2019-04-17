using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExemploWebAPIJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
     
        [HttpPost]
        public IActionResult Post(
            [FromBody] Security.Usuario usuario,
            [FromServices] Security.SigningConfiguration signingConfiguration,
            [FromServices] Security.TokenConfiguration tokenConfiguration)
        {

            if (usuario.Login == "eu" && usuario.Senha == "123")
            {

                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(usuario.Login, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
                   }
               );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao.AddSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = signingConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok(new
                {
                    authenticated = true,
                    accessToken = token,
                });

            }
            else {

                return Unauthorized();
            }

        }

        
    }
}
