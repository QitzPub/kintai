using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using System.Linq;
using Qitz.ArchitectureCore.UI;

namespace BLDKEscapeOut.View
{
    public class ManpukuGaugeView : BaseView
    {
        [SerializeField]
        Text currentManpukuText;
        [SerializeField]
        Text maxManpukuText;

        // Start is called before the first frame update
        void Start()
        {
            maxManpukuText.text = Presenter.MaxFullness + "";

            this.UpdateAsObservable().Select(_ => Presenter.CurrentFullness).DistinctUntilChanged().Subscribe(currentFullness =>
            {
                currentManpukuText.text = "" + currentFullness;
            }).AddTo(this.gameObject);
        }
    }
}