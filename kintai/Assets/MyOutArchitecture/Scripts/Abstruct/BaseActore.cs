using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.Actore
{
    public abstract class BaseActore
    {
        //魔法の力でIRepositoryを取得する
        protected IEscapeOutRepository Repository => this.GetRepository();
    }

    public static class BaseActoreExtensions
    {

        static IEscapeOutRepository repository;

        public static IEscapeOutRepository GetRepository(this BaseActore actore)
        {
            if (repository == null)
            {
                repository = UnityEngine.Object.FindObjectOfType<EscapeOutRepository>();
            }
            return repository;
        }
    }
}