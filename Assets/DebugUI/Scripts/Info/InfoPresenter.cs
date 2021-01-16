using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class InfoPresenter : DebugBasePresenter
	{
    #region 变量
	
	    [SerializeField]
	    protected CustomButton _systemButton;
	
	    [SerializeField]
	    private SystemPresenter _systemPresenter;
	
	    [SerializeField]
	    protected CustomButton _environmentButton;
	
	    [SerializeField]
	    private EnvironmentPresenter _environmentPresenter;
	    
	    [SerializeField]
	    protected CustomButton _screenButton;
	
	    [SerializeField]
	    private ScreenPresenter _screenPresenter;
	    
	    [SerializeField]
	    protected CustomButton _graphicButton;
	
	    [SerializeField]
	    private GraphicPresenter _graphicPresenter;
	    
	    [SerializeField]
	    protected CustomButton _inputButton;
	
	    [SerializeField]
	    private InputPresenter _inputPresenter;
	    
	    [SerializeField]
	    protected CustomButton _otherButton;
	
	    [SerializeField]
	    private InfoOtherPresenter _otherPresenter;
	    
    #endregion
	
	 
	    public void Init()
	    {
	        _systemPresenter.Init();
	        _environmentPresenter.Init();
	        _screenPresenter.Init();
	        _graphicPresenter.Init();
	        _inputPresenter.Init();
	        _otherPresenter.Init();
	        
	        
	        _systemButton.onClick = OnSystemClick;
	        _environmentButton.onClick = OnEnvClick;
	        _screenButton.onClick = OnScreenClick;
	        _graphicButton.onClick = OnGraphicClick;
	        _inputButton.onClick = OnInputClick;
	        _otherButton.onClick = OnOtherClick;
	    }
	
	
	    public override void Show()
	    {
	        base.Show();
	        if (_curSelected == null)
	        {
	            RefreshCurSelected(_systemButton, _systemPresenter);
	        }
	    }
	
	    void OnSystemClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _systemPresenter);
	    }
	    
	    void OnEnvClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _environmentPresenter);
	    }
	    
	    void OnScreenClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _screenPresenter);
	    }
	    
	    void OnGraphicClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _graphicPresenter);
	    }
	    
	    void OnInputClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _inputPresenter);
	    }
	    
	    void OnOtherClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _otherPresenter);
	    }
	    
	    
	    
	}
}
