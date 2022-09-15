using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.Data;
using WebApiVeiculos.Models;
using WebApiVeiculos.Repositores;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculosRepository _veiculosRepository;

        public VeiculosController(IVeiculosRepository veiculosRepository)
        {
            _veiculosRepository = veiculosRepository;
        }

        // GET: api/Veiculos
        [HttpGet]
        public async Task<IEnumerable<Veiculos>> Get()
        {
            return await _veiculosRepository.GetVeiculo();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Veiculos>> GetId(int id)
        {
            return await _veiculosRepository.GetVeiculoId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Veiculos>> CreateVeiculo([FromBody] Veiculos car)
        {
            try
            {

                var carCad = await _veiculosRepository.Create(car);
                return CreatedAtAction(nameof(GetId), new { id = carCad.Id }, carCad);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var veiculoDelete = await _veiculosRepository.GetVeiculoId(id);

            if (veiculoDelete != null)
            {
                await _veiculosRepository.Delete(veiculoDelete.Id);
            }
            else
            {
                return NotFound();
            }
            return Ok("Veiculo deletado com sucesso!");
        }

        [HttpPut("id")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Veiculos veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }
            else
            {
                await _veiculosRepository.Update(veiculo);

            }
            return Ok("Veiculo atualizado com sucesso!");
        }
    }
}
