using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iyourcar.Components.RecycleTableView
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TableViewHeader : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        public CanvasGroup canvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }
                return _canvasGroup;
            }
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }

        public void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
    }
}
