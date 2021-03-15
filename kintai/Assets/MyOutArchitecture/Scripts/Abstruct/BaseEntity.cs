using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.Repository;
using UnityEngine;

namespace BLDKEscapeOut.Entity
{
    public abstract class BaseEntity
    {
        //黒魔術でリポジトリを取得する
        protected IEscapeOutRepository Repository => this.GetRepository();
    }

    public static class BaseEntityExtensions
    {

        static IEscapeOutRepository repository;

        public static IEscapeOutRepository GetRepository(this BaseEntity entity)
        {
            if (repository == null)
            {
                repository = Object.FindObjectOfType<EscapeOutRepository>();
            }
            return repository;
        }
    }
}

