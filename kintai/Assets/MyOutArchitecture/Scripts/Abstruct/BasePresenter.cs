using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.UseCase;
using BLDKEscapeOut.Transmitter;
using UnityEngine;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.Presenter
{
    public abstract class BasePresenter : MonoBehaviour
    {
        //黒魔術でTransmitterを取得する
        protected IEscapeOutTransmitter Transmitter => this.GetTransmitter();
        //魔法の力でIRepositoryを取得する
        protected IEscapeOutRepository Repository => this.GetRepository();
    }
    public static class BasePresenterExtensions
    {

        static IEscapeOutTransmitter transmitter;

        public static IEscapeOutTransmitter GetTransmitter(this BasePresenter presenter)
        {
            if (transmitter == null)
            {
                transmitter = Object.FindObjectOfType<EscapeOutTransmitter>();
            }
            return transmitter;
        }

        static IEscapeOutRepository repository;

        public static IEscapeOutRepository GetRepository(this BasePresenter presenter)
        {
            if (repository == null)
            {
                repository = UnityEngine.Object.FindObjectOfType<EscapeOutRepository>();
            }
            return repository;
        }

    }
}