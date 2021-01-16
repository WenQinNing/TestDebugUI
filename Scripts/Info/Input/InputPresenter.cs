using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class InputPresenter : DebugBasePresenter
	{
     #region 变量
	
	    [SerializeField]
	    protected CustomButton _summaryButton;
	
	    [SerializeField]
	    private SummaryPresenter _summaryPresenter;
	
	    [SerializeField]
	    protected CustomButton _touchButton;
	
	    [SerializeField]
	    private TouchPresenter _touchPresenter;
	    
	    [SerializeField]
	    protected CustomButton _locationButton;
	
	    [SerializeField]
	    private LocationPresenter _locationPresenter;
	    
	    [SerializeField]
	    protected CustomButton _acceButton;
	
	    [SerializeField]
	    private AccelerationPresenter _accePresenter;
	    
	    [SerializeField]
	    protected CustomButton _gyroscopeButton;
	
	    [SerializeField]
	    private GyroscopePresenter _gyroscopePresenter;
	    
	    [SerializeField]
	    protected CustomButton _compassButton;
	
	    [SerializeField]
	    private CompassPresenter _compassPresenter;
	    
    #endregion
	
	    public override void Init()
	    {
	        base.Init();
	        
	        _summaryPresenter.Init();
	        _touchPresenter.Init();
	        _locationPresenter.Init();
	        _accePresenter.Init();
	        _gyroscopePresenter.Init();
	        _compassPresenter.Init();
	        
	        
	        _summaryButton.onClick = OnSummaryClick;
	        _touchButton.onClick = OnTouchClick;
	        _locationButton.onClick = OnLocationClick;
	        _acceButton.onClick = OnAcceClick;
	        _gyroscopeButton.onClick = OnGyroscopeClick;
	        _compassButton.onClick = OnCompassClick;
	    }
	
	
	    public override void Show()
	    {
	        base.Show();
	
	        if (_curSelected == null)
	        {
	            RefreshCurSelected(_summaryButton,_summaryPresenter);
	        }
	    }
	    
	
	
	    void OnSummaryClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _summaryPresenter);
	    }
	    
	    void OnTouchClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _touchPresenter);
	    }
	    
	    void OnLocationClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _locationPresenter);
	    }
	    
	    void OnAcceClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _accePresenter);
	    }
	    
	    void OnGyroscopeClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _gyroscopePresenter);
	    }
	    
	    void OnCompassClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _compassPresenter);
	    }
	}
}
