using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class ProfilerPresenter : DebugBasePresenter
	{
    #region 变量
	
	    [SerializeField]
	    protected CustomButton _memButton;
	
	    [SerializeField]
	    private MemoryPresenter _memPresenter;
	
	    [SerializeField]
	    protected CustomButton _summaryButton;
	
	    [SerializeField]
	    private ProfilerSummaryPresenter _summaryPresenter;
	
    #endregion
	
	 
	    public override void Init()
	    {
	        base.Init();
	        _memPresenter.Init();
	        _summaryPresenter.Init();
	
	        _memButton.onClick = OnSystemClick;
	        _summaryButton.onClick = OnEnvClick;
	    
	    }
	
	    void OnSystemClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _memPresenter);
	    }
	    
	    void OnEnvClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _summaryPresenter);
	    }
	
	
	    public override void Show()
	    {
	        base.Show();
	        
	        if (_curSelected == null)
	        {
	            RefreshCurSelected(_summaryButton, _summaryPresenter);
	        }
	    }
	}
}
