using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Senac.PontoWeb.Models.Repositories
{
    public class PontoRepository : ICrud<Ponto>
    {
        #region Fields

        private DbContextOptionsBuilder<PontoContext> options;

        #endregion

        #region Properties

        public DbContextOptionsBuilder<PontoContext> OptionsBuilder
        {
            get
            {
                if (options == null)
                {
                    options = new DbContextOptionsBuilder<PontoContext>();
                    options.UseSqlServer(AppSettings.Configuration.GetConnectionString("DevConnection"));
                }
                return options;
            }
        }

        #endregion

        #region Methodos

        public void Delete(Ponto entity)
        {
            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                db.Ponto.Attach(entity);
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public Ponto Details(Ponto entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Ponto entity)
        {
            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                db.Ponto.Add(entity);
                db.Colaborador.Attach(entity.Colaborador);
                db.Entry(entity.Colaborador).State = EntityState.Unchanged;
                db.SaveChanges();
            }
        }

        public List<Ponto> Retreave(Ponto entity)
        {
            List<Ponto> pontos = new List<Ponto>();

            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                pontos = db.Ponto
                    .Include(p => p.Colaborador)
                        .ToList();

                // Filters.
                pontos = pontos
                        .Where
                            (
                                p =>
                                    (!entity.ID.HasValue || p.ID.Value.Equals(entity.ID.Value))
                                    && ((entity.Colaborador == null || entity.Colaborador.Nome == null) || p.Colaborador.Nome.Contains(entity.Colaborador.Nome))
                                    && (!entity.DataHoraRegistroPonto.HasValue ||
                                        (
                                            p.DataHoraRegistroPonto.Value.Month.Equals(entity.DataHoraRegistroPonto.Value.Month)
                                            && p.DataHoraRegistroPonto.Value.Year.Equals(entity.DataHoraRegistroPonto.Value.Year))
                                        )
                                    && (!entity.IndicadorEntradaSaida.HasValue || p.IndicadorEntradaSaida.Equals(entity.IndicadorEntradaSaida))
                            )
                            .OrderBy(p => p.DataHoraRegistroPonto.Value.Day)
                                .ToList();
            }

            return pontos;
        }

        public void Update(Ponto entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
