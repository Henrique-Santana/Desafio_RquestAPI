using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBRQ.Domains;
using TestBRQ.Interfaces;
using TestBRQ.Repositories;
using TestBRQ.Senai;

namespace TestBRQ.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private IEndereco _enderecoRepository;

        public EnderecoController()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Lista todos Enderecos
        /// </summary>
        [HttpGet]
        public IActionResult Get() => Ok(_enderecoRepository.Listar());

        //// <summary>
        //// Cadastra novos Enderecos
        //// </summary>
        [HttpPost]
        public IActionResult Post(Endereco novoEndereco)
        {
            TypeMessage returnRepository = _enderecoRepository.CadastrarEndereco(novoEndereco);
            if (returnRepository.ok) return StatusCode(201, returnRepository);
            else return BadRequest(returnRepository);

        }

    }
}