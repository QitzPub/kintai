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
    [RequireComponent(typeof(Button))]
    public class HappyPointGachaButtonView : BaseView
    {
        [SerializeField]
        Text necessaryHappyPointText;
        // Start is called before the first frame update
        void Start()
        {
            necessaryHappyPointText.text = Presenter.GameSettings.RequestHappyPointToGacha+"ptで";
            var button = this.GetComponent<Button>();
            this.UpdateAsObservable().Select(_ => Presenter.CurrentHappynessPoint).DistinctUntilChanged().Subscribe(currentHappyPoint =>{

                bool enableButton = currentHappyPoint >= Presenter.GameSettings.RequestHappyPointToGacha;
                button.interactable = enableButton;

            }).AddTo(this.gameObject);
        }
    }
}