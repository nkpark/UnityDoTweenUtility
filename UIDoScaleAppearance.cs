using DG.Tweening;
using UnityEngine;
using System;

/// <summary>
/// UI 스케일 트윈으로 출현하기
/// </summary>
[AddComponentMenu("DoTween/DoScaleAppearance")]
public class UIDoScaleAppearance : UIDoTweenCustomBase
{    
    public Vector3 Scale_disappear = Vector3.zero;
    public Vector3 Scale_Beginappear = new Vector3(1.2f, 1.2f, 1f);
    public Vector3 Scale_Endappear = Vector3.one;
    public float duration_Appear = 0.2f;
    public float duration_DisAppear = 0.1f;
    public Ease easyType = Ease.Linear;
    
    void Start () {
        base.InitTween(); 
        Reset();

        if (base.isAutoStart) BeginApear();
        
    }   
    
    public void Reset()
    {
        if (tweenTarget != null)
            tweenTarget.localScale = Scale_disappear;        
    }

    public void RePlay()
    {
        Reset();
        BeginApear();
    }

    public void BeginApear()
    {
        tweenTarget.DOScale(Scale_Beginappear, duration_Appear)
                   .SetEase(easyType)
                   .OnComplete(() =>
                   {
                       EndApear();
                   });
    }

    public void EndApear()
    {
        tweenTarget.DOScale(Scale_Endappear, 0.1f)
                   .SetEase(easyType)
                   .OnComplete(() =>
                   {
                       if (_onComplete != null)
                           _onComplete();
                   });
    }

    public void Disappear(System.Action endCallBack)
    {
        tweenTarget.DOScale(Scale_disappear, duration_DisAppear)
                   .SetEase(easyType)
                   .OnComplete(() =>
                   {
                       endCallBack();
                   });
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (!isTestMode)
            return;

        if (Input.GetKeyDown(KeyCode.Keypad1))
            BeginApear();

        if (Input.GetKeyDown(KeyCode.Keypad2))
            EndApear();

        if (Input.GetKeyDown(KeyCode.Keypad3))
            RePlay();

        if (Input.GetKeyDown(KeyCode.Keypad4))
            Disappear(() =>{});
    }
#endif

}
