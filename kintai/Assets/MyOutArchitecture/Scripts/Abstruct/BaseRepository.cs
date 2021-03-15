using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.UseCase;
using BLDKEscapeOut.Transmitter;
using UnityEngine;

namespace BLDKEscapeOut.Repository
{
    public abstract class BaseRepository : MonoBehaviour
    {
        //黒魔術でTransmitterを取得する
        protected IEscapeOutTransmitter Transmitter => this.GetTransmitter();
    }
    public static class BaseRepositoryExtensions
    {

        static IEscapeOutTransmitter transmitter;

        public static IEscapeOutTransmitter GetTransmitter(this BaseRepository repository
        )
        {
            if (transmitter == null)
            {
                transmitter = Object.FindObjectOfType<EscapeOutTransmitter>();
            }
            return transmitter;
        }
    }
}