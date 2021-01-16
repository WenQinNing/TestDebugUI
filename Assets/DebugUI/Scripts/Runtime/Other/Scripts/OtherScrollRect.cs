using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AppDebugger {	
	public class OtherScrollRect : MonoBehaviour
	{
	    [SerializeField]
	    ScrollRect _scrollRect ;
	
	    [SerializeField]
	    private Text showText;
	
	
	    private void Awake()
	    {
	        showText.text = string.Empty;
	    }
	
	    public void RefreshText(string toShow)
	    {
	        showText.text = toShow;
	        
	        if (showText.preferredHeight > showText.rectTransform.rect.height)
	        {
	            _scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 
	                showText.preferredHeight);
	        }
	    }
	}
}
