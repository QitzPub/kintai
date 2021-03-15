using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;
using System.Collections.Generic;

public static class MyTweener
{
    public static void ZoomInTween(Transform transform, TweenCallback onCompleteAction)
    {
        ZoomTween(transform, new Vector3(0.8f,0.8f), Vector3.one, onCompleteAction);
        Fade(transform, 0, 1);

    }

    public static void ZoomOutTween(Transform transform, TweenCallback onCompleteAction)
    {
        ZoomTween(transform, Vector3.one, new Vector3(0.8f, 0.8f), onCompleteAction);
        Fade(transform, 1, 0);
    }

    static void Fade(Transform transform, float startAlpha, float endAlpha)
    {
        var canvasGroup = transform.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = transform.gameObject.AddComponent<CanvasGroup>();

        }
        canvasGroup.alpha = startAlpha;
        canvasGroup.DOFade(endAlpha, 0.3f);

    }

    static Tweener zoomTweener;

    static void ZoomTween(Transform transform, Vector3 startScale, Vector3 endScale, TweenCallback onCompleteAction, float delay = 0.3f)
    {

        zoomTweener?.Kill();
        transform.DOKill(true);
        transform.localScale = startScale;
        zoomTweener=transform.DOScale(endScale, delay)
            .OnComplete(()=> {
                zoomTweener?.Kill();
                onCompleteAction();
            });
    
    }

    public static void FadeInCanvasGroupDelayed(List<CanvasGroup> canvasGroups)
    {
        for (int i = 0; i < canvasGroups.Count; i++)
        {
            var canvasGroup = canvasGroups[i];
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                DOVirtual.DelayedCall(0.5f + i * 0.15f, () => {
                    canvasGroup?
                        .DOFade(1, 0.4f);
                    canvasGroup.transform
                        .DOLocalMoveY(40, 0.4f)
                        .From(true)
                        .SetRelative();
                });
            }
        }

    }

    public static void ShakeScale(Transform transform, Vector3 initialScale, Vector3 maxScale, Vector3 endScale, float duration, float delay)
    {
        transform.localScale = initialScale;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(
            transform
                .DOScale(maxScale, duration)
                .SetDelay(delay)
            );

        sequence.Append(
            transform.DOScale(endScale, duration)
            );

    }

    static Tweener slideOutTweener;

    public static void SlideOutToLeft(Transform transform, TweenCallback onCompleteAction)
    {
        //slideOutTweener?.Complete();
        slideOutTweener?.Kill();

        slideOutTweener = transform
            .DOLocalMoveX(-2000, 0.25f)
            .SetDelay(0.05f)
            .SetRelative()
            .OnComplete(()=> {
                slideOutTweener?.Kill();
                onCompleteAction(); 
            });

    }

}
