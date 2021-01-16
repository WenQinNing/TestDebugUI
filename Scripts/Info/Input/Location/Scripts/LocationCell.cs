using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class LocationCell : DebugBaseCell
	{
	
	    
	    
	    private LocationPieceInfo data;
	    
	    public virtual void Init(LocationPieceInfo data)
	    {
	        base.Init();
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
