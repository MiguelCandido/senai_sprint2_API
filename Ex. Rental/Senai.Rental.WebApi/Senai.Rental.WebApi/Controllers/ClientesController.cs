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
    public class ClientesController : ControllerBase
    {
        private IClientesRepository _ClienteRepository { get; set; }

        public ClientesController()
        {
            _ClienteRepository = new ClientesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ClienteDomain> listaClientes = _ClienteRepository.ListarTodos();

            return Ok(listaClientes);
        }

        [HttpPost]
        public IActionResult Post(ClienteDomain cliente)
        {
            try
            {
                _ClienteRepository.Cadastrar(cliente);
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
                _ClienteRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                ClienteDomain clienteResposta = _ClienteRepository.BuscarPorId(id);
                if (clienteResposta != null)
                {
                    return Ok(clienteResposta);
                }
                return NotFound("O cliente não foi encontrado :(");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
        [HttpPut]
        public IActionResult Put(ClienteDomain cliente)
        {
            ClienteDomain clienteUPDT = _ClienteRepository.BuscarPorId(cliente.IdCliente);

            if (clienteUPDT != null)
            {
                try
                {
                    _ClienteRepository.Atualizar(cliente);
                    return StatusCode(204);
                }
                catch (Exception error)
                {

                    return BadRequest(error);
                }
            }
            return NotFound("O cliente não foi encontrado :(");
        }
    }
}
