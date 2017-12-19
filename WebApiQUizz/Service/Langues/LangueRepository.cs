using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Threading.Tasks;

namespace WebApiQUizz.Service
{
    /// <summary>
    /// Classe de gestion de la langue
    /// </summary>
    public class LangueRepository : ILangueRepository
    {

        //private readonly IGenericRepository<Langue> _langueRepository;
        public LangueRepository(IGenericRepository<Langue> langueRepository)
        {
           // _langueRepository = langueRepository;
        }
        // private QuizzContext db = new QuizzContext();
        /// <summary>
        /// Retourne la liste des langues
        /// </summary>
        /// <returns></returns>
        //public IQueryable<Langue> GetAll()
        //{
        //    return _langueRepository.GetAll();
        //}

        //public Langue GetById(int id)
        //{
        //    return _langueRepository.GetByKey(id);
        //}
        //public global::Models.Langue Add(global::Models.Langue item)
        //{
        //    throw new NotImplementedException();
        //}
        //public IQueryable<Langue> GetAll()
        //{
        //    return _langueRepository.GetAll();
        //}

        //public Task<Langue> GetByKey(int id)
        //{
        //    return _langueRepository.GetByKey(id);
        //}
        //public Langue Add(Langue item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Langue Attach(Langue item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Langue Create()
        //{
        //    throw new NotImplementedException();
        //}

       

        //public Langue Remove(Langue item)
        //{
        //    throw new NotImplementedException();
        //}

    }
}