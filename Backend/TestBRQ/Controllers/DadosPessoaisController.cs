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
    public class DadosPessoaisController : ControllerBase
    {
        private IDadosPessoais _dadosPessoaisRepository;
        public DadosPessoaisController()
        {
            _dadosPessoaisRepository = new DadosPessoaisRepository();
        }

        /// <summary>
        /// Listar todos Dados Pessoais
        /// </summary>
        [HttpGet]
        public IActionResult Get() => Ok(_dadosPessoaisRepository.Listar());

        //// <summary>
        //// Cadastra Dados Pessoais
        //// </summary>
        [HttpPost]
        public IActionResult Post(DadosPessoais data)
        {

            TypeMessage returnRepository = _dadosPessoaisRepository.Cadastrar(data);
            if (returnRepository.ok) return StatusCode(201, returnRepository);
            else return BadRequest(returnRepository);

        }

    }
}