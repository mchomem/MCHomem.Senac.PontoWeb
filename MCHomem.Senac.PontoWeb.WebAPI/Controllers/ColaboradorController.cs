using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MCHomem.Senac.PontoWeb.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<String> Get()
        {
            return new string[] { "Iniciado" };
        }


        [HttpGet]
        [Route("/api/[controller]/all")]
        public IEnumerable<Colaborador> GetAll()
        {
            return new ColaboradorRepository()
                .Retreave(new Colaborador());
        }

        [HttpGet]
        [Route("/api/[controller]/colaborador")]
        public IEnumerable<Colaborador> GetColaborador([FromBody] Colaborador colaborador)        
        {
            return new ColaboradorRepository()
                .Retreave(colaborador);
        }

        // POST api/<ColaboradorController>
        [HttpPost]
        public void Post([FromBody] Colaborador colaborador)
        {
            new ColaboradorRepository()
                .Insert(colaborador);
        }

        // PUT api/<ColaboradorController>/5
        [HttpPut]
        public void Put([FromBody] Colaborador colaborador)
        {
            new ColaboradorRepository()
                .Update(colaborador);
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
