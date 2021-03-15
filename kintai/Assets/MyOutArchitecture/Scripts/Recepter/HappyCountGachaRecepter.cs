using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;

namespace BLDKEscapeOut.Recepter
{
    [RequireComponent(typeof(Button))]
    public class HappyCountGachaRecepter : BaseRecepter
    {
        [SerializeField]
        int gachaCount;
        [SerializeField]
        int srKakutiCount;
        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(() => {
                Controller.ContinuousConsumeHappypointAndTurn(gachaCount, srKakutiCount);
            });
        }

    }
}