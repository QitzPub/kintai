using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseDialog : MonoBehaviour
{
    Action closeAction;
    // Start is called before the first frame update
    void Start()
    {
        MyTweener.ZoomInTween(transform, () => { });
    }

    public void Initialize(Action closeAction)
    {
        this.closeAction = closeAction;
    }

    public void Close()
    {
        MyTweener.ZoomOutTween(transform, () => {
            closeAction?.Invoke();
            Destroy(gameObject);
        });
    }

}
