using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class MemDetailSection : DebugBaseCell
	{
	  
	
	    [SerializeField]
	    private  Text _typeText;
	    
	    [SerializeField]
	    private  Text _sizeText;
	    
	    private MemDetailInfo data;
	
	    
	
	    public virtual void Init(MemDetailInfo data)
	    {
	        base.Init();
	        this.data = data;
	
	        
	
	        _nameText.text = data.Name;
	        _typeText.text = data.TypeStr;
	        
	        if (data.Size == 0)
	        {
	            _sizeText.text = data.SizeStr;
	        }
	        else
	        {
	            _sizeText.text = DebuggerUtil.GetByteLengthString(data.Size);
	        }
	    }
	    
	   
	    
	    
	}
}
