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
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _EstudioRepository { get; set; }

        public EstudiosController()
        {
            _EstudioRepository = new EstudiosRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<EstudiosDomain> listaEstudios = _EstudioRepository.ListarTodos();

            return Ok(listaEstudios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                EstudiosDomain estudioResposta = _EstudioRepository.BuscarPorId(id);
                if (estudioResposta != null)
                {
                    return Ok(estudioResposta);
                }
                return NotFound("O estudio não foi encontrado :P");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Post(EstudiosDomain estudio)
        {
            try
            {
                _EstudioRepository.Cadastrar(estudio);
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
                _EstudioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(EstudiosDomain estudio, int id)
        {
            EstudiosDomain estudioUPDT = _EstudioRepository.BuscarPorId(id);

            if (estudioUPDT != null)
            {
                try
                {
                    _EstudioRepository.Atualizar(estudio, id);
                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }
            return NotFound("O estudio não foi encontrado :(");
        }


    }
}
