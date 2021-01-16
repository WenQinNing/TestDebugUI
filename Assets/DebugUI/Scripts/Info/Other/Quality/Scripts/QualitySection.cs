using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class QualitySection : DebugBaseCell
	{
	    [SerializeField]
	    private  Text _nameText;
	
	    private QualitySectionInfo data;
	    
	    public virtual void Init(QualitySectionInfo data)
	    {
	        this.data = data;
	
	        _nameText.text = data.Name;
	    }
	}
}
