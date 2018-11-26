using DG.Tweening;
using UnityEngine;

/// <summary>
/// 버튼 클릭시 스케일 트윈을 줍니다.
/// </summary>
[AddComponentMenu("DoTween/DoTweenButtonScale")]
public class UIDoTweenButtonScale : MonoBehaviour
{
    public Transform tweenTarget;
    public Vector3 PressedDownScale = new Vector3(0.95f, 0.95f, 0.95f);
    public Vector3 PressedUpScale = new Vector3(1.03f, 1.03f, 1.03f);
    public float duration = 0.1f;

    private Vector3 originScale = Vector3.zero;
    private bool mStarted = false;
    //private Sequence sq;


    private void Start()
    {
        InitTweenTarget();
    }

    private void InitTweenTarget()
    {
        if (!mStarted)
        {
            mStarted = true;

            if (tweenTarget == null)
                tweenTarget = transform;

            originScale = tweenTarget.localScale;
        }
    }

    Tweener tw_press;
    Tweener tw_release;
    private void OnPress(bool isPressed)
    {
        InitTweenTarget();

        if (isPressed)
        {
            tw_press = tweenTarget.DOScale(PressedDownScale, duration).SetEase(Ease.InOutBounce);            
        }
        else
        {
            tw_release = tweenTarget.DOScale(PressedUpScale, duration).SetEase(Ease.InOutBounce)
                        .OnComplete( ()=> tweenTarget.DOScale(originScale, duration).SetEase(Ease.InOutBounce));

        }
    }

    private void OnDestroy()
    {
        if (tw_press.IsValid())
            if (tw_press.IsPlaying()) DOTween.Kill(tw_press);
        
        if (tw_release.IsValid())
            if (tw_release.IsPlaying()) DOTween.Kill(tw_release);
        
    }
}