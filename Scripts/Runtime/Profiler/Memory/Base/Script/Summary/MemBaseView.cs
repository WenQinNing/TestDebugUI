using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	[RequireComponent(typeof(CanvasGroup))]
	public class MemBaseView<T> : DebugBaseView where T : Object
	{
    #region 变量
	    [SerializeField]
	    private MemBaseScrollRect _scrollRect;
	    
	    [SerializeField]
	    private MemBaseHeader header;
	
	    private UnityAction onButtonClick;
	    
    #endregion
	    
	    public override void Init()
	    {
	        
	        if (_scrollRect == null)
	        {
	            _scrollRect = GetComponent<MemBaseScrollRect>();
	        }
	        base.Init();
	        if (_scrollRect != null)
	        {
	            _scrollRect.Init(OnSetHeader);
	        }
	        else
	        {
	            print(gameObject);
	        }
	    }
	
	    void OnButtonClick()
	    {
	        onButtonClick?.Invoke();
	    }
	
	
	    public void SetOnButtonClick(UnityAction act)
	    {
	        onButtonClick = act;
	    }
	
	    void OnSetHeader(GameObject headerGo)
	    {
	        header =  headerGo.GetComponent<MemBaseHeader>();
	        header.SetOnClickAct(OnButtonClick);
	    }
	
	
	    public void SetSumText(string text)
	    {
	        header.SetText(text);
	    }
	    
	    public void RefreshData(List<MemBaseSectionInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	
	}
}
