using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class GraphicCell : DebugBaseCell
	{
	
	    
	    
	    private GraphicPieceInfo data;
	    
	    public virtual void Init(GraphicPieceInfo data)
	    {
	        base.Init();
	        this.data = data;
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
