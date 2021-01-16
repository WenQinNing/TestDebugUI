using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Iyourcar.Components.RecycleTableView
{
    [RequireComponent(typeof(CanvasGroup))]
    public class TableViewCell : MonoBehaviour
    {
        public string identifier = "";
        public int sectionIndex = 0;
        public int cellIndex = 0;

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
