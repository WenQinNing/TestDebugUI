using System;
using System.Collections;
using System.Collections.Generic;
using AppDebugger;
using UnityEngine;
using UnityEngine.UI;

namespace AppDebugger {	
	public class DebugPresenter : DebugBasePresenter
	{
	
	    [SerializeField]
	    private SmallDebugPresenter _smallDebugPresenter;
	
    #region 按钮选择
	
	        [SerializeField]
	        protected CustomButton _consoleButton;
	        
	        [SerializeField]
	        protected CustomButton _informationButton;
	        
	        [SerializeField]
	        protected CustomButton _profilerButton;
	        
	        [SerializeField]
	        protected CustomButton _otherButton;
	        
	        [SerializeField]
	        private Button _closeButton;
	        
	        [SerializeField]
	        private ConsolePresenter _consolePresenter;
	        
	        [SerializeField]
	        private InfoPresenter _infoPresenter;
	
	        [SerializeField]
	        private ProfilerPresenter _profilerPresenter;
	
	        [SerializeField]
	        private OtherPresenter _otherPresenter;

	        [SerializeField]
	        private AlertPresenter _alertPresenter;
	        
    #endregion
	
	    private void Awake()
	    {
	        Init();
	        OnConsoleClick(_consoleButton);
	    }
	    
	    public  override void Init()
	    {
	        base.Init();
	        
	        _infoPresenter.Init();
	        _consolePresenter.Init();
	        _profilerPresenter.Init();
	        _otherPresenter.Init();
	        _smallDebugPresenter.Init();
	        _alertPresenter.Init();
	        
	        _consoleButton.onClick = OnConsoleClick;
	        _informationButton.onClick = OnInfoClick;
	        _profilerButton.onClick = OnProfilerClick;
	        _otherButton.onClick = OnOtherClick;
	        _closeButton.onClick.AddListener(OnCloseClick);
	        _smallDebugPresenter.SetOnClick(OnOpenClick);
	    }
	    
	    void OnCloseClick()
	    {
	       Hide();
	       _smallDebugPresenter.Show();
	    }
	    
	    void OnOpenClick()
	    {
	       Show();
	    }
	
	
	    void OnInfoClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _infoPresenter);
	    }
	    
	    void OnProfilerClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _profilerPresenter);
	    }
	    
	    void OnConsoleClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _consolePresenter);
	    }
	
	    void OnOtherClick(CustomButton button)
	    {
	        RefreshCurSelected(button, _otherPresenter);
	    }
	    
	}
}
