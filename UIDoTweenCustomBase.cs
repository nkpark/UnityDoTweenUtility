using DG.Tweening;
using UnityEngine;
using System;

public class UIDoTweenCustomBase : MonoBehaviour {

    [Header("트윈 트렌스폼")]
    public Transform tweenTarget;
    public Action _onComplete = null;

    [Header("자동 시작")]
    public bool isAutoStart = false;
    /// <summary>트윈 타겟이 존재하는가</summary>
    public bool ExistTweenTarget{ get { return (tweenTarget != null); } }
    protected bool isInit = false;

#if UNITY_EDITOR
    /// <summary>트윈 테스트 모드</summary>
    public bool isTestMode = false;
#endif

    void Start () {
        InitTween();
    }

    public void InitTween()
    {
        if (!isInit)
        {
            isInit = true;

            if (tweenTarget == null)
                tweenTarget = transform;
        }
    }

    /// <summary>트윈 완료 이후실행될 액션</summary>    
    public void SetOnComplete(Action _action)
    {
        _onComplete = _action;
    }
    
}
