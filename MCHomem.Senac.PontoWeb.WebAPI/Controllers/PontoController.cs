﻿using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MCHomem.Senac.PontoWeb.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        // GET: api/<ColaboradorController>/colaborador-ponto
        [HttpGet]
        [Route("/api/[controller]/ponto")]
        public IEnumerable<Ponto> GetPontoColaborador([FromBody] Ponto ponto)
        {
            return new PontoRepository()
                .Retreave(ponto);
        }

        // POST api/<PontoController>
        [HttpPost]
        public void Post([FromBody] Ponto ponto)
        {
            new PontoRepository()
                .Insert(ponto);
        }

        // DELETE api/<PontoController>/5
        [HttpDelete("{id}")]
        public void Delete(Int32 id)
        {
            new PontoRepository()
                .Delete(new Ponto() { ID = Convert.ToInt32(id)});
        }
    }
}
