using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AppDebugger
{
    public class ButtonAnimationBase : UIBehaviour
    {
        public const float animationTime = 0.3f;

        private RectTransform _targetTrans;

        protected RectTransform targetTrans
        {
            get
            {
                if (_targetTrans == null)
                {
                    _targetTrans = transform as RectTransform;
                }

                return _targetTrans;
            }
        }


        private CustomButton _button;

        protected CustomButton button
        {
            get
            {
                if (_button == null)
                {
                    _button = GetComponent<CustomButton>();
                }

                return _button;
            }
        }


        protected override void Start()
        {
            button.statusDidChange += StatusDidChange;
            Refresh();
        }


        public virtual void StatusDidChange(bool animation)
        {
            throw new NotImplementedException();
        }

        public virtual void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
