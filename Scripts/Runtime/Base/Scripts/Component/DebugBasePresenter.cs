using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class DebugBasePresenter : MonoBehaviour 
	{
	    [SerializeField]
	    protected DebugBaseView _view;
	    
	    protected bool isShowing;
	    
	    protected DebugBasePresenter _curSelected;
	
	    protected CustomButton _curSelectedBtn;
	
	
	    public virtual void Init()
	    {
	        if (_view == null)
	        {
	            _view = GetComponent<DebugBaseView>();
	        }
	
	        if (_view != null)
	        {
	            _view.Init();
	            Hide();
	        }
	        
	    }
	    
	    protected  virtual void Update()
	    {
	        if (isShowing)
	        {
	            UpdateShow();
	        }
	    }
	
	    public virtual void Show()
	    {
	        if (_view != null)
	        {
	            _view.Show(null);
	            isShowing = true;
	        }
	    }
	    
	    public virtual void Hide()
	    {
	        if (_view != null)
	        {
	            _view.Hide(null);
	            isShowing = false;
	        }
	       
	    }
	    
	    protected virtual void UpdateShow()
	    {
	        
	    }
	    
	    protected void RefreshCurSelected(CustomButton button, DebugBasePresenter basePresenter)
	    {
	        HideCurSelected();
	
	        _curSelectedBtn = button;
	        _curSelectedBtn.SetStatus(CustomButton.Status.Selected);
	        _curSelected = basePresenter;
	        _curSelected.Show();
	    }
	
	    protected void HideCurSelected()
	    {
	        if (_curSelected != null)
	        {
	            _curSelected.Hide();
	        }
	
	        if (_curSelectedBtn != null)
	        {
	            _curSelectedBtn.SetStatus(CustomButton.Status.Normal);
	        }
	    }
	}
}
