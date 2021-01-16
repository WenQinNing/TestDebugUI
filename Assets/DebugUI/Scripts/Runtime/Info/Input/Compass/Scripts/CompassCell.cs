
namespace AppDebugger {	
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
	
	public class CompassCell : DebugBaseCell
	{
	
	    
	    
	    private CompassPieceInfo data;
	    
	    public virtual void Init(CompassPieceInfo data)
	    {
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
