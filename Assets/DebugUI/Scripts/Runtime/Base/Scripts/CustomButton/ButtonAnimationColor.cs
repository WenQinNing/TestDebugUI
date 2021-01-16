using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AppDebugger
{
    

    public class ButtonAnimationColor : ButtonAnimationBase
    {
    
        public Image targetImage;
        public Text targetText;

        public Color normalColor = new Color(0.75f, 0.86f, 1.0f);
        public Color pressedColor = new Color(0.75f, 0.86f, 1.0f);
        public Color disabledColor = new Color(0.75f, 0.86f, 1.0f);

        public float duration = 0.1f;
        public Ease ease = Ease.InOutQuad;

    
    
        public override void StatusDidChange(bool animation)
        {
            Refresh();
        }

        public override void Refresh()
        {
            CustomButton.Status status = button.status;
 
            if (status == CustomButton.Status.Normal)
            {
                if (targetImage != null)
                {
                    targetImage.DOColor(normalColor, duration).SetEase(ease);
                }
        
                if (targetText != null)
                {
                    targetText.DOColor(normalColor, duration).SetEase(ease);
                }
            }
            else if (status == CustomButton.Status.Selected)
            {
                if (targetImage != null)
                {
                    targetImage.DOColor(pressedColor, duration).SetEase(ease);
                }
        
                if (targetText != null)
                {
                    targetText.DOColor(pressedColor, duration).SetEase(ease);
                }
            }
            else
            {
                if (targetImage != null)
                {
                    targetImage.DOColor(disabledColor, duration).SetEase(ease);
                }
        
                if (targetText != null)
                {
                    targetText.DOColor(disabledColor, duration).SetEase(ease);
                }
            }
        }
    }
}
