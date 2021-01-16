using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AppDebugger {	
	public class SmallDebugPresenter : DebugBasePresenter
	{
	    private int _frameCount = 0;
	    private float _passedTime = 1.0f;
	    private float _fpsDeltatime = 1.0f;
	    private int _realtimeFPS = 0;
	
	    private SmallDebugView _smallDebugView;
	
	    private UnityAction onClick;
	
	    public override void Init()
	    {
	        base.Init();
	        
	        if (_view != null)
	        {
	            _smallDebugView = _view as SmallDebugView;
	        }
	
	        if (_smallDebugView != null)
	        {
	            _smallDebugView.SetOnClick(OnOpenClick);
	        }
	        Show();
	    }
	
	    public void SetOnClick(UnityAction onClick)
	    {
	        this.onClick = onClick;
	    }
	    
	    void OnOpenClick()
	    {
	        onClick?.Invoke();
	    }
	    
	    protected override void UpdateShow()
	    {
	        base.UpdateShow();
	        _frameCount++;
	        _passedTime += Time.deltaTime;
	
	        if (_passedTime >= _fpsDeltatime)
	        {
	            _realtimeFPS = (int) (_frameCount / _passedTime);
	            _passedTime = 0.0f;
	            _frameCount = 0;
	
	            _smallDebugView.RefreshText(_realtimeFPS);
	            
	        }
	    }
	}
}
