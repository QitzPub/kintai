using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.Repository;


namespace BLDKEscapeOut.Transmitter
{
    public abstract class BaseTransmitter : MonoBehaviour
    {
        //魔法の力でIRepositoryを取得する
        protected IEscapeOutRepository Repository => this.GetRepository();
    }
    public static class BaseTransmitterExtensions
    {

        static IEscapeOutRepository repository;

        public static IEscapeOutRepository GetRepository(this BaseTransmitter transmitter)
        {
            if (repository == null)
            {
                repository = UnityEngine.Object.FindObjectOfType<EscapeOutRepository>();
            }
            return repository;
        }
    }
}