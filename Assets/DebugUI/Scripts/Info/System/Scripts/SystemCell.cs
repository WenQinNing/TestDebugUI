using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class SystemCell : DebugBaseCell
	{
	
	    
	    
	    private SystemPieceInfo data;
	    
	    public virtual void Init(SystemPieceInfo data)
	    {
	        base.Init();
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
