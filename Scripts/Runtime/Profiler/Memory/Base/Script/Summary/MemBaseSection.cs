using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class MemBaseSection : DebugBaseCell
	{
	  
	
	    [SerializeField]
	    private  Text _countText;
	    
	    [SerializeField]
	    private  Text _sizeText;
	    
	    private MemBaseSectionInfo data;
	
	    
	
	    public virtual void Init(MemBaseSectionInfo data)
	    {
	        base.Init();
	        this.data = data;
	
	        
	
	        _nameText.text = data.Name;
	        _countText.text = data.CountStr;
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
