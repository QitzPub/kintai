using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoadButton : Button
{
    [SerializeField] string scene;
    [SerializeField] SceneLoadTweenType tweenType;
    [SerializeField] LoadSceneMode loadSceneMode;

    public void SetScene(string scene)
    {
        this.scene = scene;
    }

    void Start()
    {
        this.onClick.AddListener(() =>
        {
            SceneLoaderWithTween.LoadScene(scene, tweenType, loadSceneMode);
        });

    }
}
