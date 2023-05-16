using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup howToPlay;
    private Tween fadeTween;

    private void Start()
    {
        StartCoroutine(testFading());
    }
    private void Fade(float endVal, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        fadeTween = howToPlay.DOFade(endVal, duration);
        fadeTween.onComplete += onEnd;

    }
    public void Fadeout(float duration)
    {
        Fade(0f, duration, () =>
         {
             howToPlay.interactable= false;
             howToPlay.blocksRaycasts= false;
         });
    }
    protected IEnumerator testFading()
    {
        yield return new WaitForSeconds(5f);
        Fadeout(1f);
    }
}
