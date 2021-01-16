using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class WebGLCell : DebugBaseCell
	{
	
	    
	    
	    private WebGLPieceInfo data;
	    
	    public virtual void Init(WebGLPieceInfo data)
	    {
	        
	        base.Init();
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
