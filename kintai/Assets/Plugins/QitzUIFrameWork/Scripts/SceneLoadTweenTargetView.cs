using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public enum SceneLoadTweenType
{
    CenterScale,
    SlideInFromBottom,
    SlideInFromRight,
    SlideOutToLeft,

}

public class SceneLoadTweenTargetView : MonoBehaviour
{
    [SerializeField] SceneLoadTweenType tweenType = SceneLoadTweenType.CenterScale;

    void Start()
    {

        //シールドの作成
        //シールドの作成
        GameObject obj = (GameObject)Resources.Load("Shiled");
        // プレハブを元にオブジェクトを生成する
        GameObject shiled = (GameObject)Object.Instantiate(obj);
        shiled.transform.localScale = Vector3.one;
        shiled.transform.localPosition = Vector3.zero;
        Destroy(shiled, 0.75f);

        switch (tweenType)
        {
            case SceneLoadTweenType.CenterScale:
                MyTweener.ZoomInTween(transform, () => { });
                break;
            case SceneLoadTweenType.SlideInFromBottom:
                transform
                    .DOLocalMoveY(-3000, 0.5f)
                    .SetDelay(0.25f)
                    .From(true)
                    .SetRelative();
                break;
            case SceneLoadTweenType.SlideInFromRight:
                transform
                    .DOLocalMoveX(2000, 0.25f)
                    .SetDelay(0.25f)
                    .From(true)
                    .SetRelative();
                break;
            case SceneLoadTweenType.SlideOutToLeft:
                transform
                    .DOLocalMoveX(-2000, 0.25f)
                    .SetDelay(0.25f)
                    .From(true)
                    .SetRelative();
                break;
            default:
                break;
        }

    }

}
