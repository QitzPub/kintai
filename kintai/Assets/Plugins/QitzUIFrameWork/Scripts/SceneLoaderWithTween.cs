using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class SceneLoaderWithTween
{

    static string prevSceneName;
    static bool loading = false;

    public static void LoadScene(
        string scene,
        SceneLoadTweenType tweenType = SceneLoadTweenType.CenterScale,
        LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {

        if (loading) return;
        loading = true;
        //シールドの作成
        GameObject obj = (GameObject)Resources.Load("Shiled");
        // プレハブを元にオブジェクトを生成する
        GameObject shiled = (GameObject)Object.Instantiate(obj);
        shiled.transform.localScale = Vector3.one;
        shiled.transform.localPosition = Vector3.zero;

        var tweenTarget = Object.FindObjectOfType<SceneLoadTweenTargetView>();
        prevSceneName = SceneManager.GetActiveScene().name;
        var async = SceneManager.LoadSceneAsync(scene, loadSceneMode);
        async.completed += (compleate) =>
        {
            loading = false;
        };
        if (tweenTarget != null)
        {
            async.allowSceneActivation = false;

            switch (tweenType)
            {
                case SceneLoadTweenType.CenterScale:
                    MyTweener.ZoomOutTween(tweenTarget.transform, () => async.allowSceneActivation = true);
                    return;

                case SceneLoadTweenType.SlideOutToLeft:
                    MyTweener.SlideOutToLeft(tweenTarget.transform, () => async.allowSceneActivation = true);
                    return;
            }

        }

    }
    public static void ReturnLoadScene()
    {
        LoadScene(prevSceneName);
    }

}
