using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class ConsoleSelected : MonoBehaviour
	{
	    [SerializeField]
	    ScrollRect _scrollRect ;
	
	    [SerializeField]
	    private Text selectedText;
	
	    [SerializeField]
	    private Button _copyButton;
	
	    private RectTransform _scrollRectTransform;
	
	    [SerializeField]
	    private float _showHeight = 272;
	    
	    private UnityAction<string> onCopied;

	    
	    
	    private void Awake()
	    {
	        if (_scrollRect != null)
	        {
	            _scrollRectTransform = _scrollRect.GetComponent<RectTransform>();
	        }
	
	        if (_copyButton != null)
	        {
	            _copyButton.onClick.AddListener(OnCopyClick);
	        }
	        
	        selectedText.text = string.Empty;
	    }
	
	    void OnCopyClick()
	    {
	        GUIUtility.systemCopyBuffer = selectedText.text;
	        onCopied?.Invoke(selectedText.text);
	    }
	    
	    public void SetOnCopied(UnityAction<string> onCopiedAct)
	    {
		    onCopied = onCopiedAct;
	    }
	    
	    public void AdjustHeight(bool isNormal)
	    {
	        if (_scrollRectTransform == null)
	        {
	            return;
	        }
	        
	        if (isNormal)
	        {
	            _scrollRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _showHeight);
	        }
	        else
	        {
	            _scrollRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
	        }
	        
	    }
	    
	    public void RefreshText(ConsoleNode consoleNode)
	    {
	        selectedText.color = consoleNode.Color;
	        
	        selectedText.text = consoleNode.LogMessage + "\n" + consoleNode.StackTrack;
	        
	        // if (selectedText.preferredHeight > selectedText.rectTransform.rect.height)
	        // {
	            _scrollRect.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 
	                selectedText.preferredHeight);
	        // }
	        
	        _scrollRect.content.anchoredPosition = Vector2.zero;
	    }
	}
}
