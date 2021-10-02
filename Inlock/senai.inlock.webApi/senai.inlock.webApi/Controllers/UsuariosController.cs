using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _UsuariosRepository { get; set; }

        public UsuariosController()
        {
            _UsuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Logar(UsuariosDomain userlog)
        {
            try
            {
                UsuariosDomain userResposta = _UsuariosRepository.Logar(userlog);
                if (userResposta != null)
                {   

                    var InlockClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, userResposta.Email),
                        new Claim(JwtRegisteredClaimNames.Jti,userResposta.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role,userResposta.IdTipo.ToString())

                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inlock-Chave-manha"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                        issuer: "Inlock.webAPI",               // emissor do token
                        audience: "Inlock.webAPI",             // destinatário do token
                        claims: InlockClaims,                  // dados definidos acima (linha 38)
                        expires: DateTime.Now.AddHours(1),  // tempo de expiração
                        signingCredentials: creds              // credenciais do token
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }


                return NotFound("Email ou senha inválidos");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
