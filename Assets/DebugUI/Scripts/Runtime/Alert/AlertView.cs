using System.Collections;
using System.Collections.Generic;
using AppDebugger;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AlertView : DebugBaseView
{
    [SerializeField]
    private Text _text;
    

    private float duration = 1f;
    
    public void RefreshStr(string str)
    {
        _text.text = str;
    }

    public override void Show(UnityAction onShow = null)
    {
        base.Show(onShow);
        
        DOTween.To(() => WindowCanvasGroup.alpha,
            alpha =>
            {
                WindowCanvasGroup.alpha = alpha;
            },
            0,
            duration).SetEase(Ease.InOutQuad).onComplete = () =>
        {
            Hide();
        };
    }

    
    
}
