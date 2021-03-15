using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;
using UnityEngine.SceneManagement;

public class AutoSceneLoadWithTween : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] SceneLoadTweenType tweenType;
    [SerializeField] int delayMilliSeconds;
    // Start is called before the first frame update
    async void Start()
    {
        await UniTask.Delay(delayMilliSeconds);
        SceneLoaderWithTween.LoadScene(scene, tweenType, LoadSceneMode.Single);
    }
}
