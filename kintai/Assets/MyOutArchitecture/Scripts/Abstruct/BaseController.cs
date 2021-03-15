using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.UseCase;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.Repository;
using BLDKEscapeOut.Transmitter;
using UnityEngine;

namespace BLDKEscapeOut.Controller
{
    public abstract class BaseController : MonoBehaviour
    {
        //黒魔術でTransmitterを取得する
        protected IEscapeOutTransmitter Transmitter => this.GetTransmitter();
        protected IEscapeOutRepository Repository => this.GetRepository();
    }

    public static class BaseControllerExtensions
    {

        static IEscapeOutTransmitter transmitter;

        public static IEscapeOutTransmitter GetTransmitter(this BaseController controller
        )
        {
            if (transmitter == null)
            {
                transmitter = Object.FindObjectOfType<EscapeOutTransmitter>();
            }
            return transmitter;
        }

        static IEscapeOutRepository repository;

        public static IEscapeOutRepository GetRepository(this BaseController controller
        )
        {
            if (repository == null)
            {
                repository = Object.FindObjectOfType<EscapeOutRepository>();
            }
            return repository;
        }

    }
}