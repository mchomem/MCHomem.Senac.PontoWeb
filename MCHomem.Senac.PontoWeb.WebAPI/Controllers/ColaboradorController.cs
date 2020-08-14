using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Colaborador>> GetAll()
        {
            List<Colaborador> colaboradores = new ColaboradorRepository().Retreave(new Colaborador());
            TaskCompletionSource<IEnumerable<Colaborador>> tsc = new TaskCompletionSource<IEnumerable<Colaborador>>();
            tsc.SetResult(colaboradores);
            return await tsc.Task;
        }

        [HttpGet]
        [Route("/api/[controller]/colaborador")]
        //public IEnumerable<Colaborador> GetColaborador([FromBody] Colaborador colaborador)        
        public async Task<IEnumerable<Colaborador>> GetColaborador([FromBody] Colaborador colaborador)
        {
            List<Colaborador> colaboradores = new ColaboradorRepository().Retreave(colaborador);
            TaskCompletionSource<IEnumerable<Colaborador>> tsc = new TaskCompletionSource<IEnumerable<Colaborador>>();
            tsc.SetResult(colaboradores);
            return await tsc.Task;
        }

        // POST api/<ColaboradorController>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Colaborador colaborador)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            new ColaboradorRepository().Insert(colaborador);
            response = new HttpResponseMessage(HttpStatusCode.Created);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        // PUT api/<ColaboradorController>/5
        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] Colaborador colaborador)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            new ColaboradorRepository().Update(colaborador);
            response = new HttpResponseMessage(HttpStatusCode.Created);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        // DELETE api/<ColaboradorController>/5
        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(String id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            new ColaboradorRepository().Delete(new Colaborador() { ID = Guid.Parse(id) });
            response = new HttpResponseMessage(HttpStatusCode.NoContent);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }
    }
}
