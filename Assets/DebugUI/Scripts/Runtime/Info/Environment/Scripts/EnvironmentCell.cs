using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class EnvironmentCell : DebugBaseCell
	{
	
	    
	    
	    private EnvironmentPieceInfo data;
	    
	    public virtual void Init(EnvironmentPieceInfo data)
	    {
	        this.data = data;
	        base.Init();
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
