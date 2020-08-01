using System.Collections.Generic;

namespace MCHomem.Senac.PontoWeb.Models.Repositories
{
    interface ICrud<E>
    {
        #region Abstract methods

        public void Insert(E entity);
        public void Update(E entity);
        public void Delete(E entity);
        public E Details(E entity);
        public List<E> Retreave(E entity);

        #endregion
    }
}
