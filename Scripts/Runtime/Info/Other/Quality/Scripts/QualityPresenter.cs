using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class QualityPresenter : DebugBasePresenter
	{
	    private QualityModel _model = new QualityModel();
	    
	
	    private int currentQualityLevel;
	
	    private bool _applyExpensiveChanges;
	
	    [SerializeField]
	    private QualityHeader _header;
	
	    public override void Init()
	    {
	        base.Init();
	         (_view as QualityView).SetHeaderCb(OnHeaderSet);
	    }
	
	    void OnHeaderSet(QualityHeader _header)
	    {
	        this._header = _header;
	        _header.SetOnFastestToggle(OnFastestToggle);
	        _header.SetOnFastToggle(OnFastToggle);
	        _header.SetOnSimpleToggle(OnSimpleToggle);
	        _header.SetOnGoodToggle(OnGoodToggle);
	        _header.SetOnBeautifulToggle(OnBeautifulToggle);
	        _header.SetOnFantasticToggle(OnFantasticToggle);
	    }
	    
	    
	    public override void Show()
	    {
	        base.Show();
	        List<QualitySectionInfo> toShows = _model.GetData();
	       
	        _header.InitToggle();
	        (_view as QualityView).RefreshData(toShows);
	    }
	
	    void OnFastestToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 0);
	    }
	    
	    void OnFastToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 1);
	    }
	    
	    void OnSimpleToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 2);
	    }
	    
	    void OnGoodToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 3);
	    }
	    
	    void OnBeautifulToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 4);
	    }
	    
	    void OnFantasticToggle(bool isOn)
	    {
	        SetQualityLevel(isOn, 5);
	    }
	    
	  
	    
	    
	    private void SetQualityLevel(bool isOn, int newQualityLevel)
	    {
	        if (isOn)
	        {
	            if (currentQualityLevel != newQualityLevel)
	            {
	                currentQualityLevel = newQualityLevel;
	                QualitySettings.SetQualityLevel(currentQualityLevel, _applyExpensiveChanges);
	                // print(" QualityHeader SetQualityLevel " + QualitySettings.GetQualityLevel());
	            }
	        }
	    }
	    
	    
	}
}
