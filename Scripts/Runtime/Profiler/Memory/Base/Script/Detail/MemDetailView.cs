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
	public class MemDetailView<T> : DebugBaseView where T : Object
	{
    #region 变量
	    [SerializeField]
	    private MemDetailScrollRect _scrollRect;
	    
	    [SerializeField]
	    private MemDetailHeader header;
	
	    private UnityAction onButtonClick;
	    
    #endregion
	    
	    public override void Init()
	    {
	        if (_scrollRect == null)
	        {
	            _scrollRect = GetComponent<MemDetailScrollRect>();
	        }
	        
	        base.Init();
	        if (_scrollRect != null)
	        {
	            _scrollRect.Init(OnSetHeader);
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
	        header =  headerGo.GetComponent<MemDetailHeader>();
	        header.SetOnClickAct(OnButtonClick);
	    }
	
	
	    public void SetSumText(string text)
	    {
	        header.SetText(text);
	    }
	    
	    public void RefreshData(List<MemDetailInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	
	}
}
