using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class AccelerationCell : DebugBaseCell
	{
	
	    
	    
	    private AccelerationPieceInfo data;
	    
	    public virtual void Init(AccelerationPieceInfo data)
	    {
	        this.data = data;
	        base.Init();
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
