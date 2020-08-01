using MCHomem.Senac.PontoWeb.Models.Entities;
using MCHomem.Senac.PontoWeb.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCHomem.Senac.PontoWeb.Models.Repositories
{
    public class ColaboradorRepository : ICrud<Colaborador>
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

        #region Methods

        public void Delete(Colaborador entity)
        {
            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                db.Colaborador.Attach(entity);
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public Colaborador Details(Colaborador entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Colaborador entity)
        {
            Colaborador colaborador = new Colaborador();
            colaborador.ID = Guid.NewGuid();
            colaborador.Nome = entity.Nome;

            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                db.Colaborador.Add(colaborador);
                db.SaveChanges();
            }
        }

        public List<Colaborador> Retreave(Colaborador entity)
        {
            List<Colaborador> colaboradores = new List<Colaborador>();

            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                colaboradores = db.Colaborador
                        .ToList();

                // Filters.
                colaboradores =
                    colaboradores
                        .Where
                        (c =>
                            (!entity.ID.HasValue || c.ID.Value.Equals(entity.ID.Value))
                            && (entity.Nome == null || c.Nome.Contains(entity.Nome))
                        )
                        .ToList();
            }

            return colaboradores;
        }

        public void Update(Colaborador entity)
        {
            using (PontoContext db = new PontoContext(OptionsBuilder.Options))
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        #endregion
    }
}
