using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class InfoOtherPresenter : DebugBasePresenter
	{
      #region 变量
	
	    [SerializeField]
	    protected CustomButton _sceneButton;
	
	    [SerializeField]
	    private ScenePresenter _scenePresenter;
	
	    [SerializeField]
	    protected CustomButton _pathButton;
	
	    [SerializeField]
	    private PathPresenter _pathPresenter;
	    
	    [SerializeField]
	    protected CustomButton _timeButton;
	
	    [SerializeField]
	    private TimePresenter _timePresenter;
	    
	    [SerializeField]
	    protected CustomButton _qualityButton;
	
	    [SerializeField]
	    private QualityPresenter _qualityPresenter;
	    
	    [SerializeField]
	    protected CustomButton _webGLButton;
	
	    [SerializeField]
	    private WebGLPresenter _webGlPresenter;
	
    #endregion
	
	    public override void Init()
	    {
	        base.Init();
	        _scenePresenter.Init();
	        _pathPresenter.Init();
	        _timePresenter.Init();
	        _qualityPresenter.Init();
	        _webGlPresenter.Init();
	
	
	        _sceneButton.onClick = OnSceneClick;
	        _pathButton.onClick = OnPathClick;
	        _timeButton.onClick = OnTimeClick;
	        _qualityButton.onClick = OnQualityClick;
	        _webGLButton.onClick = OnWebGLClick;
	    }
	
	
	    public override void Show()
	    {
	        if (_curSelected == null)
	        {
	            RefreshCurSelected(_sceneButton, _scenePresenter);
	
	        }
	        base.Show();
	    }
	    
	
	    void OnSceneClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _scenePresenter);
	    }
	    
	    void OnPathClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _pathPresenter);
	    }
	    
	    void OnTimeClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _timePresenter);
	    }
	    
	    void OnQualityClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _qualityPresenter);
	    }
	    
	    void OnWebGLClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _webGlPresenter);
	    }
	    
	}
}
