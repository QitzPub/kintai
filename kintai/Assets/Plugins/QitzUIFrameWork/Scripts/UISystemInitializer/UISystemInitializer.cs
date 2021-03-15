using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemInitializer: MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    public void UISystemInitialize()
    {
        Debug.Log("OnRuntimeMethodLoad");
    }
}
