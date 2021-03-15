using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;
using System.Linq;
using Qitz.ArchitectureCore.UI;
using UnityEngine.SceneManagement;

namespace BLDKEscapeOut.View
{
    public class HappyCountGachaButtonView : BaseView
    {
        [SerializeField]
        Button button;
        [SerializeField]
        Text necessaryHappyPointText;
        [SerializeField]
        int gachaTrunCount;

        void Start()
        {
            necessaryHappyPointText.text = Presenter.GameSettings.ContinuousConsumeHappypoint * gachaTrunCount + "ptで";
            this.UpdateAsObservable().Select(_ => Presenter.CurrentHappynessPoint).DistinctUntilChanged().Subscribe(currentHappyPoint => {

                bool enableButton = currentHappyPoint >= Presenter.GameSettings.ContinuousConsumeHappypoint* gachaTrunCount;
                button.interactable = enableButton;

            }).AddTo(this.gameObject);
        }

    }
}