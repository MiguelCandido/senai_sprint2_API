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
    public class VeiculosController : ControllerBase
    {
        private IVeiculosRepository _VeiculosRepository { get; set; }

        public VeiculosController()
        {
            _VeiculosRepository = new VeiculosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _VeiculosRepository.ListarTodos();

            return Ok(listaVeiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                VeiculoDomain veiculoResposta = _VeiculosRepository.BuscarPorId(id);
                if (veiculoResposta != null)
                {
                    return Ok(veiculoResposta);
                }
                return NotFound("O veiculo não foi encontrado :(");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain veiculo)
        {
            try
            {
                _VeiculosRepository.Cadastrar(veiculo);
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
                _VeiculosRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPut]
        public IActionResult Put(VeiculoDomain veiculo)
        {
            VeiculoDomain veiculoUPDT = _VeiculosRepository.BuscarPorId(veiculo.IdVeiculo);

            if (veiculoUPDT != null)
            {
                try
                {
                    _VeiculosRepository.Atualizar(veiculo);
                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }
            return NotFound("O veiculo não foi encontrado :(");
        }
    }
}
