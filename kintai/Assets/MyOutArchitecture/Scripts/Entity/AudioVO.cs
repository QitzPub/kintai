using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class AudioVO : BaseEntity
    {
        [SerializeField]
        AudioType audioType;
        public AudioType AudioType => audioType;

        [SerializeField]
        AudioClip audioClip;
        public AudioClip AudioClip => audioClip;

    }

    public enum AudioType
    {
        //SE
        NONE,
        DECISION,
        CANCEL,
        JUMP,
        CRASH,
        BIKE,

        //AUDIO
        IN_GAME_BGM,
        OUT_GAME_BGM,
    }
}