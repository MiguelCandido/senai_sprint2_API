using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> listaJogos = _JogoRepository.ListarTodos();

            return Ok(listaJogos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                JogosDomain jogoResposta = _JogoRepository.BuscarPorId(id);
                if (jogoResposta != null)
                {
                    return Ok(jogoResposta);
                }
                return NotFound("O jogo não foi encontrado :P");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogosDomain jogo)
        {
            try
            {
                _JogoRepository.Cadastrar(jogo);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _JogoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(JogosDomain jogo, int id)
        {
            JogosDomain jogoUPDT = _JogoRepository.BuscarPorId(id);

            if (jogoUPDT != null)
            {
                try
                {
                    _JogoRepository.Atualizar(jogo, id);
                    return StatusCode(204);
                }

                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }
            return NotFound("O jogo não foi encontrado :(");
        }
    }
}
