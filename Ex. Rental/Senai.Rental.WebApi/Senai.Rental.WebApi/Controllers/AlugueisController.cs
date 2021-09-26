using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAluguelRepository _AluguelRepository { get; set; }

        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _AluguelRepository.ListarTodos();

            return Ok(listaAlugueis);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                AluguelDomain aluguelresposta = _AluguelRepository.BuscarPorId(id);
                if(aluguelresposta != null)
                {
                    return Ok(aluguelresposta);
                }
                return NotFound("O aluguel não foi encontrado :(");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain aluguel)
        {
            try
            {
                _AluguelRepository.Cadastrar(aluguel);
                return StatusCode(201);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _AluguelRepository.Deletar(id);
                return StatusCode(204);
                }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPut]
        public IActionResult Put(AluguelDomain aluguel)
        {
            AluguelDomain aluguelUPDT = _AluguelRepository.BuscarPorId(aluguel.idAluguel);

            if (aluguelUPDT != null)
            {
                try
                {
                    _AluguelRepository.Atualizar(aluguel);
                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }
            return NotFound("O aluguel não foi encontrado :(");
        }

    }
}
