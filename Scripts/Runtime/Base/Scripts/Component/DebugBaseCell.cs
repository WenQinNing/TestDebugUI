using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.UI;

namespace AppDebugger {	
	public class DebugBaseCell : TableViewCell
	{
	    
	    [SerializeField]
	    protected  Text _nameText;
	    
	    [SerializeField]
	    protected  Text _valueText;
	    
	    public virtual void Init()
	    {
	        if (_nameText != null)
	        {
	            _nameText.resizeTextForBestFit = true;
	        }
	        
	        if (_valueText != null)
	        {
	            _valueText.resizeTextForBestFit = true;
	        }
	
	        
	    }
	    
	    
	}
}
