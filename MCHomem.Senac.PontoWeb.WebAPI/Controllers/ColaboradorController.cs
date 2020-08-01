using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCHomem.Senac.PontoWeb.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        // GET: 
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new String[] { "Colaborador 1", "Colaborador 2" };
        }

        [HttpGet]
        [Route("/api/[controller]/colaborador")]
        public IEnumerable<Colaborador> GetColaborador([FromBody] Colaborador colaborador)
        {
            return new ColaboradorRepository().Retreave(colaborador);
        }

        // GET api/<ColaboradorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ColaboradorController>
        [HttpPost]
        public void Post([FromBody] Colaborador colaborador)
        {
            new ColaboradorRepository().Insert(colaborador);
        }

        // PUT api/<ColaboradorController>/5
        [HttpPut]
        public void Put([FromBody] Colaborador colaborador)
        {
            new ColaboradorRepository().Update(colaborador);
        }

        // DELETE api/<ColaboradorController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            new ColaboradorRepository()
                .Delete(new Colaborador() { ID = Guid.Parse(id) });
        }
    }
}
