using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCHomem.Senac.PontoWeb.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        [HttpGet]
        [Route("/api/[controller]/ponto-colaborador")]
        public async Task<IEnumerable<Ponto>> GetPontoColaborador(Guid colaboradorID)
        {
            Colaborador colaborador = new Colaborador();
            colaborador.ID = colaboradorID;

            List<Ponto> pontos = new PontoRepository().Retreave(new Ponto() { Colaborador = colaborador });
            TaskCompletionSource<IEnumerable<Ponto>> tsc = new TaskCompletionSource<IEnumerable<Ponto>>();
            tsc.SetResult(pontos);
            return await tsc.Task;
        }

        [HttpGet]
        public async Task<IEnumerable<Ponto>> GetPontoColaborador([FromBody] Ponto ponto)
        {
            List<Ponto> pontos = new PontoRepository().Retreave(ponto);
            TaskCompletionSource<IEnumerable<Ponto>> tsc = new TaskCompletionSource<IEnumerable<Ponto>>();
            tsc.SetResult(pontos);
            return await tsc.Task;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Ponto ponto)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            new PontoRepository().Insert(ponto);
            response = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }

        [HttpDelete("{id}")]
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            new PontoRepository().Delete(new Ponto() { ID = Convert.ToInt32(id) });
            response = new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            TaskCompletionSource<HttpResponseMessage> tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return await tsc.Task;
        }
    }
}
