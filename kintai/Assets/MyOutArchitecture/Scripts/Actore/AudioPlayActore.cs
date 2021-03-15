using System;
using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Entity;
using BLDKEscapeOut.UseCase;
using UnityEngine;
using UniRx;
using System.Linq;
using UniRx.Async;

namespace BLDKEscapeOut.Actore
{
    public class AudioPlayActore : MonoBehaviour, AudioPlayUseCase
    {
        //ボリューム保存用のkeyとデフォルト値
        private const string BGM_VOLUME_KEY = "BGM_VOLUME_KEY";
        private const string SE_VOLUME_KEY = "SE_VOLUME_KEY";
        private const float BGM_VOLUME_DEFULT = 1.0f;
        private const float SE_VOLUME_DEFULT = 1.0f;

        //BGMがフェードするのにかかる時間
        const float BGM_FADE_SPEED_RATE_HIGH = 0.9f;
        const float BGM_FADE_SPEED_RATE_LOW = 0.3f;
        private float _bgmFadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH;

        //次流すBGM名、SE名
        private BLDKEscapeOut.Entity.AudioType _nextBGMName;
        private BLDKEscapeOut.Entity.AudioType _nextSEName;

        //BGMをフェードアウト中か
        private bool _isFadeOut = false;

        //BGM用、SE用に分けてオーディオソースを持つ
        [SerializeField]
        AudioSource AttachBGMSource, AttachSESource;

        ////全Audioを保持
        //private Dictionary<string, AudioClip> _bgmDic, _seDic;

        [SerializeField]
        List<AudioVO> bgmList, seList;

        BLDKEscapeOut.Entity.AudioType currentPlayBGMName = Entity.AudioType.NONE;


        //=================================================================================
        //初期化
        //=================================================================================

        private void Awake()
        {
        }

        //private void Start()
        //{
        //    AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
        //    AttachSESource.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEFULT);
        //}

        //=================================================================================
        //SE
        //=================================================================================

        /// <summary>
        /// 指定したファイル名のSEを流す。第二引数のdelayに指定した時間だけ再生までの間隔を空ける
        /// </summary>
        void _PlaySE(BLDKEscapeOut.Entity.AudioType seName, float delay = 0.0f)
        {
            _nextSEName = seName;
            Invoke("DelayPlaySE", delay);
        }

        void DelayPlaySE()
        {
            AttachSESource.PlayOneShot(seList.FirstOrDefault(s=>s.AudioType == _nextSEName).AudioClip);
        }

        //=================================================================================
        //BGM
        //=================================================================================

        /// <summary>
        /// 指定したファイル名のBGMを流す。ただし既に流れている場合は前の曲をフェードアウトさせてから。
        /// 第二引数のfadeSpeedRateに指定した割合でフェードアウトするスピードが変わる
        /// </summary>
        void _PlayBGM(BLDKEscapeOut.Entity.AudioType bgmName, float fadeSpeedRate = BGM_FADE_SPEED_RATE_HIGH)
        {

            Debug.Log("PlayBGM:"+ bgmName);
            //現在BGMが流れていない時はそのまま流す
            if (!AttachBGMSource.isPlaying)
            {
                _nextBGMName = BLDKEscapeOut.Entity.AudioType.NONE;
                AttachBGMSource.clip = bgmList.FirstOrDefault(s => s.AudioType == bgmName).AudioClip;
                currentPlayBGMName = bgmName;
                AttachBGMSource.Play();
            }
            //違うBGMが流れている時は、流れているBGMをフェードアウトさせてから次を流す。同じBGMが流れている時はスルー
            else if (currentPlayBGMName != bgmName)
            {
                _nextBGMName = bgmName;
                FadeOutBGM(fadeSpeedRate);
            }

        }

        /// <summary>
        /// 現在流れている曲をフェードアウトさせる
        /// fadeSpeedRateに指定した割合でフェードアウトするスピードが変わる
        /// </summary>
        void FadeOutBGM(float fadeSpeedRate = BGM_FADE_SPEED_RATE_LOW)
        {
            _bgmFadeSpeedRate = fadeSpeedRate;
            _isFadeOut = true;
        }

        void Update()
        {
            if (!_isFadeOut)
            {
                return;
            }

            //徐々にボリュームを下げていき、ボリュームが0になったらボリュームを戻し次の曲を流す
            AttachBGMSource.volume -= Time.deltaTime * _bgmFadeSpeedRate;
            if (AttachBGMSource.volume <= 0)
            {
                AttachBGMSource.Stop();
                AttachBGMSource.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEFULT);
                _isFadeOut = false;

                if (_nextBGMName != Entity.AudioType.NONE)
                {
                    PlayBGM(_nextBGMName);
                }
            }

        }

        //=================================================================================
        //音量変更
        //=================================================================================

        ///// <summary>
        ///// BGMとSEのボリュームを別々に変更&保存
        ///// </summary>
        //public void ChangeVolume(float BGMVolume, float SEVolume)
        //{
        //    AttachBGMSource.volume = BGMVolume;
        //    AttachSESource.volume = SEVolume;
        //}

        public void PlaySE(BLDKEscapeOut.Entity.AudioType audioType)
        {
            _PlaySE(audioType);
        }

        public void PlayBGM(BLDKEscapeOut.Entity.AudioType audioType)
        {
            _PlayBGM(audioType);
        }

    }
}