using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class QualityCell : DebugBaseCell
	{
	
	    
	    
	    private QualityPieceInfo data;
	    
	    public virtual void Init(QualityPieceInfo data)
	    {
	        this.data = data;
	        base.Init();
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
