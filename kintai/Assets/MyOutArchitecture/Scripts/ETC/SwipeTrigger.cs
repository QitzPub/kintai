using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Async;
using UniRx.Triggers;
using System;
using System.Linq;

public class SwipeTrigger : MonoBehaviour
{
    Subject<SwipeInfomation> swipeSubject = new Subject<SwipeInfomation>();
    public IObservable<SwipeInfomation> SwipeTriggr => swipeSubject;


    public struct SwipeInfomation
    {
        public float DeltaPostionX { get; private set; }
        public float DeltaPostionY { get; private set; }
        public float Speed { get; private set; }
        public SwipeInfomation(float x, float y, float speed)
        {
            DeltaPostionX = x;
            DeltaPostionY = y;
            Speed = speed;
        }
    }
    public IObservable<Vector2> SwipeVecAsObservable
    {
        get
        {
            return swipeVecAsObservable.AsObservable();
        }
    }
    private Subject<Vector2> swipeVecAsObservable = new Subject<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        var mouseDownPosStream = this.UpdateAsObservable()
        .Where(a => Input.GetMouseButtonDown(0))
        .Select(a => Input.mousePosition);

        var mouseUpStream = this.UpdateAsObservable()
        .Where(a => Input.GetMouseButtonUp(0));

        var mouseMoveStream = this.UpdateAsObservable()
        .Where(a => Input.GetMouseButton(0))
        .Select(a => Input.mousePosition);

        var threshold = 20f; // 閾値
        var inputWaitSec = 1; // 移動待ち時間限界

        mouseDownPosStream
        .SelectMany(startPos => mouseMoveStream.Select(currentPos => currentPos - startPos))
        .DistinctUntilChanged()
        .SkipWhile(startDelta => Mathf.Abs(startDelta.magnitude) < threshold) // クリック開始位置からの移動量が閾値を超えるまではスキップ
        .Take(1) // 閾値を超えた時の最初の移動量を取得して終了
        .TakeUntil(mouseUpStream) // クリックが離されても終了
        .TakeUntil(Observable.Timer(System.TimeSpan.FromSeconds(inputWaitSec))) // 移動にまごついていても終了
        .RepeatUntilDestroy(gameObject) // 終了した時用にリピート
        .Subscribe(vec =>
        {
            // Debug.Log(string.Format("vec:{0}", vec));
            swipeVecAsObservable.OnNext(vec);
        });
    }
}

