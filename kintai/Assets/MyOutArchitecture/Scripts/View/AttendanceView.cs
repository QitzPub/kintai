using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using BLDKEscapeOut.IPresenter;

public class AttendanceView : BaseView
{
    [SerializeField]
    Text connectingText;
    [SerializeField]
    Text errorText;
    [SerializeField]
    Text errorDetailText;
    [SerializeField]
    Text doneText;

    // Start is called before the first frame update
    void Start()
    {
        Presenter.AttenancePostResult.Subscribe(
            result => {
                connectingText.gameObject.SetActive(false);
                if (CommunicationResult.SUCCESS.Equals(result))
                {
                    doneText.gameObject.SetActive(true);
                }
                else if(CommunicationResult.FAILD.Equals(result))
                {
                    errorText.gameObject.SetActive(true);
                    errorDetailText.gameObject.SetActive(true);
                }
                else if (CommunicationResult.NONE.Equals(result))
                {
                    // なにか処理
                }
            }
        ).AddTo(this.gameObject);
    }
}
